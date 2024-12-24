using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

/// <summary>
/// Contraoller action class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    IContact contact_ = null;
    public ContactsController(IContact contact)
    {
        contact_ = contact;
    }
    
    /// <summary>
    /// This action method is use to get all contacts
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Contact>> GetContacts()
    {
        return contact_.LoadContacts();
    }

    /// <summary>
    /// This action method is used for geting contact by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Contact> GetContact(int id)
    {
        var contact = contact_.GetContact(id);
        if (contact == null) return NotFound();
        return contact;
    }

    /// <summary>
    /// this action method is used to add new contact.
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<Contact> CreateContact(Contact contact)
    {
        
        return contact_.CreateContact(contact);
    }

    /// <summary>
    /// this action method is used to update existing contact.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedContact"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult UpdateContact(int id, Contact updatedContact)
    {
       contact_.UpdateContact(id, updatedContact);
        return NoContent();
    }

    /// <summary>
    /// This action method is used to delete contact.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteContact(int id)
    {
        contact_.DeleteContact(id);
        return NoContent();
    }
}
