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
      Get ["/form"] = _ =>{
        return View["contactForm.cshtml"];
      };
      Post ["/added"] = _ =>{
        Contact newContact = new Contact(Request.Form["new-first"],
                                          Request.Form["new-last"],
                                          Request.Form["new-number"],
                                          Request.Form["new-address"]);
        // List<Contact> allContacts = Contact.GetAll();
        return View["added.cshtml", newContact];
      };
      Get["/contact/{id}"] = parameters => {
      Contact contact = Contact.Find(parameters.id);
        return View["/single.cshtml", contact];
      };
      Post["/cleared"] = _ => {
        Contact.ClearAll();
        return View["cleared.cshtml"];
      };
    }
  }
}
