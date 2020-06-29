using GitHub.Controllers;
using GitHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace GitHub.ViewModel
{
    public class GigsFormViewModel
    {
        public int Id { get; set; }
        public DateTime GetDateTime()
        {
         return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }
        [TimeVal]
        [Required]
        public string Time { get; set; }

        [Required]
        public int Genre { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update = 
                    (c => c.Update(this));

                Expression<Func<GigsController, ActionResult>> create = 
                    (c => c.Create(this));

              var action= (Id != 0) ? update : create;
            

                return ((action.Body as MethodCallExpression).Method.Name);
            }
                }


        public IEnumerable<Genre> Genres { get; set; }


    }
}