using System.Net.Http;
using TVMazeScraper.Models;
using TVMazeScraper.Data;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace TVMazeScraper.Services;

public class TVMazeService
{
    private readonly HttpClient _httpClient;
    private readonly TVMazeContext _context;

    public TVMazeService(HttpClient httpClient, TVMazeContext context)
    {
        _httpClient = httpClient;
        _context = context;
    }

    public async Task GetShowData()
    {
        try {
            // fetch the shows
            var response = await _httpClient.GetAsync("https://api.tvmaze.com/shows");
            response.EnsureSuccessStatusCode();

            var showString = await response.Content.ReadAsStringAsync();
            var showsList = JsonConvert.DeserializeObject<List<Show>>(showString);

            if (showsList == null) { return; }

            foreach (var show in showsList) {

                var existingShow = await _context.Shows.FindAsync(show.id);

                if (existingShow == null) {
                    // fetch the cast of the each show
                    var castResponse = await _httpClient.GetAsync($"https://api.tvmaze.com/shows/{show.id}/cast");
                    if (castResponse.StatusCode == System.Net.HttpStatusCode.TooManyRequests) {
                        // Wait before retrying
                        await Task.Delay(2000); // Adjust the delay as needed (2 seconds)
                        continue; // Retry the request
                    }

                    var castStr = await castResponse.Content.ReadAsStringAsync();
                    var castList = JsonConvert.DeserializeObject<List<CastInfo>>(castStr);

                    if (castList != null) {
                        foreach (var castInfo in castList) {
                            var existingPerson = await _context.Person.FindAsync(castInfo.person.id);

                            if (existingPerson != null) {
                                // If the person exists, use the existing one
                                castInfo.person = existingPerson;
                            }
                            else {
                                // If not, add the new person
                                _context.Person.Add(castInfo.person);
                            }
                        }
                        show.Cast = castList.ToList();
                    }

                    // Add show to the database
                     _context.Shows.Add(show);
                }
            }
            // Persist all the scraped data to the database
            await _context.SaveChangesAsync();
        }
        catch (System.Exception ex)
        {
            
            Console.WriteLine($"Error during scraping: {ex.Message}");
        }
    }
}
