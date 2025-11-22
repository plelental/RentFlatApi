using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentFlatApi.Infrastructure.Context;

namespace RentFlatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScaDemoController : ControllerBase
    {
        private readonly RentContext _context;

        public ScaDemoController(RentContext context)
        {
            _context = context;
        }

        // Vulnerability 1: SQL Injection
        // CWE-89: Improper Neutralization of Special Elements used in an SQL Command ('SQL Injection')
        [HttpGet("sqli")]
        public IActionResult GetFlatByName(string name)
        {
            // VULNERABLE: Concatenating user input directly into SQL query
            var query = "SELECT * FROM Flats WHERE Name = '" + name + "'";
            var result = _context.Flat.FromSql(query);
            return Ok(result);
        }

        // Vulnerability 2: Cross-Site Scripting (XSS)
        // CWE-79: Improper Neutralization of Input During Web Page Generation ('Cross-site Scripting')
        [HttpGet("xss")]
        public IActionResult ReflectInput(string input)
        {
            // VULNERABLE: Returning user input directly as HTML content
            return Content($"<html><body><h1>Hello, {input}</h1></body></html>", "text/html");
        }

        // Vulnerability 3: Path Traversal
        // CWE-22: Improper Limitation of a Pathname to a Restricted Directory ('Path Traversal')
        [HttpGet("readfile")]
        public IActionResult ReadFile(string path)
        {
            try
            {
                // VULNERABLE: Reading file from user-supplied path without validation
                var content = System.IO.File.ReadAllText(path);
                return Ok(content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Vulnerability 4: Hardcoded Credentials
        // CWE-798: Use of Hard-coded Credentials
        [HttpGet("credentials")]
        public IActionResult GetCredentials()
        {
            // VULNERABLE: Hardcoded AWS Access Key
            var awsAccessKey = "AKIAIOSFODNN7EXAMPLE";
            var awsSecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";

            return Ok("Credentials used internally (simulated)");
        }
    }
}
