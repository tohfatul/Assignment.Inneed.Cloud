using Microsoft.AspNetCore.Mvc;

namespace Assignment.Inneed.API.models;

public class CustomProblemDetails:ProblemDetails
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}
