using Microsoft.AspNetCore.Mvc;

namespace MovieManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : Controller
{
    // movie list
    private static List<Movie> movies = new List<Movie>();
    
    // Add new movie
    [HttpPost]
    public ActionResult AddMovie(Movie movie)
    {
        movie.Id = movies.Count + 1;
        movies.Add(movie);
        return Ok("Movie added!");
    }
    
    // List all movies
    [HttpGet]
    public ActionResult<List<Movie>> GetMovies()
    {
        return Ok(movies);
    }
    
    // Delete a movie by ID
    [HttpDelete("{id}")]
    public ActionResult DeleteMovie(int id)
    {
        var movie = movies.FirstOrDefault(m => m.Id == id);

        if (movie == null)
        {
            return NotFound("Movie not found!");
        }
        movies.Remove(movie);
        return Ok("Movie removed!");
    }
}