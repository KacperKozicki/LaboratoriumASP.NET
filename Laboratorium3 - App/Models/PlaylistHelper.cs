using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3___App.Models
{
    public static class PlaylistHelper
    {
        public static string ConvertPublicStatus(bool isPublic)
        {
            return isPublic ? "publiczna" : "prywatna";
        }
    }



}
