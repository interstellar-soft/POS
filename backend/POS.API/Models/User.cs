using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace POS.API.Models;

public class User : IdentityUser<int>
{
}
