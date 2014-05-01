using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CCC2014.Filters;
using CCC2014.ViewModels;
using WebMatrix.WebData;

namespace CCC2014.Controllers
{
    [InitializeSimpleMembership]
    [Authorize(Roles = "Administrator")]
    public class PermissionsController : Controller
    {
        //
        // GET: /Permissions/
       
        public ActionResult Index()
        {
            var roles = new string[]{};
           if(WebSecurity.Initialized)
                roles = Roles.GetAllRoles();

          // TempData["failure"] = null;

            return View(roles);
        }

        [HttpPost]
        public ActionResult PermissionsToUser(string username,string permission)
        {
            if (Roles.IsUserInRole(username, permission))

            Roles.AddUserToRole(username, permission);
            
            return View();
        }

        [HttpPost]
        public ActionResult UserPermissions(string username)
        {
            
            var userRoles = Roles.GetRolesForUser(username);
            return View(userRoles);
        }
        //
        // GET: /Permissions/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Permissions/Create

        public ActionResult Create()
        {
            TempData["failure"] = null;
            return View();
        }

        //
        // POST: /Permissions/Create

        [HttpPost]
        public ActionResult Create(string permission)
        {
            try
            {
                // TODO: Add insert logic here
                if (!Roles.RoleExists(permission))
                {
                    TempData["success"] = "Ensure it does not exist before trying again.";
                    Roles.CreateRole(permission);
                }else{
                    TempData["failure"] = "Ensure it does not exist before trying again.";
                   // TempData["failure"] = permission;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
         
        //
        // GET: /Permissions/Edit/5

        public ActionResult Edit(int id)
        {
            // find the model then pass the model of to
            // the view

            return View();
        }

        //
        // POST: /Permissions/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add Edit Roles logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Permissions/Delete/5

        [HttpPost]
        public ActionResult Delete(string permission)
        {
            if (Roles.RoleExists(permission))
                Roles.DeleteRole(permission);
            //return View();
            return RedirectToActionPermanent("Index", "Account");
        }

        //
        // POST: /Permissions/Delete/5

        [HttpPost]
        public ActionResult DeleteUserFromRole(string username,string permission)
        {
            try
            {
                // TODO: Add delete logic here
                if (Roles.IsUserInRole(username, permission))
                    Roles.RemoveUserFromRole(username, permission);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            // returns the roles to the user passed to show the role was removed
            // Thinking of a checkboxes
        }
    }
}
