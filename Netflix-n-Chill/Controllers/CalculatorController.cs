using System.Transactions;
using Microsoft.AspNetCore.Mvc;
//this one was the first controller i made just for learning purposes
//things will get much more advanced for now on
namespace Netflix_n_Chill.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    #region Constructor

    //DI here
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }
    #endregion

    #region Gets

    //name doesnt define the route
    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    //[HttpGet(Name ="sum/{firstNumber}/{secondNumber}")]
    public IActionResult GetSum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) & IsNumeric(secondNumber))
        {
            return Ok("Sum result: " + Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber));
        }
        return BadRequest("Invalid Input!");
    }

    [HttpGet("subtract/{firstNumber}/{secondNumber}")]
    public IActionResult GetSubtract(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) & IsNumeric(secondNumber))
        {
            return Ok($"subtraction result: {Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber)}");
        }
        return BadRequest("Invalid Input!");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult GetDivision(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && secondNumber != "0")
        {
            return Ok(Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber));
        }
        return BadRequest("Invalid numbers!");
    }
    [HttpGet("multiply/{firstNumber}/{secondNumber}")]
    public IActionResult GetMultiply(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            return Ok(Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber));
        }
        return BadRequest("Invalid numbers!");
    }

    [HttpGet("square-root/{firstNumber}")]
    public IActionResult GetSquareRoot(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            return Ok((Math.Sqrt(Convert.ToDouble(firstNumber))));
        }
        return BadRequest("Invalid numbers!");
    }

    [HttpGet("mean/{firstNumber}/{secondNumber}/{thirdNumber}")]
    public IActionResult GetArithmeticMean(string firstNumber,
                                           string secondNumber,
                                           string thirdNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && IsNumeric(thirdNumber))
        {
            return Ok((Convert.ToDecimal(firstNumber) +
                       Convert.ToDecimal(secondNumber) +
                       Convert.ToDecimal(thirdNumber)) / 3);
        }
        return BadRequest("Invalid numbers!");
    }
    #endregion

    #region Others
    private static bool IsNumeric(string strNumber)
    {
        return double.TryParse(strNumber,
                               System.Globalization.NumberStyles.Any,
                               System.Globalization.NumberFormatInfo.InvariantInfo,
                               out var number);
    }
    #endregion
}
