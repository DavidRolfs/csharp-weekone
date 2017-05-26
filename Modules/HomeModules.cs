using Nancy;
using System.Collections.Generic;
using Address.Objects;

namespace Address
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ =>{
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get ["/contact/add"] = _ =>{
        return View["contactForm.cshtml"];
      };
      Post ["/contact/new"] = _ =>{
        Contact newContact = new Contact(Request.Form["new-first"],
                                          Request.Form["new-last"],
                                          Request.Form["new-number"],
                                          Request.Form["new-address"],
                                          Request.Form["new-city"],
                                          Request.Form["new-state"],
                                          Request.Form["new-zip"]);
        return View["added.cshtml", newContact];
      };
      Get["/contact/{id}"] = parameters => {
      Contact contact = Contact.Find(parameters.id);
        return View["/single.cshtml", contact];
      };
      Post["/contacts/clear"] = _ => {
        Contact.ClearAll();
        return View["cleared.cshtml"];
      };
    }
  }
}
