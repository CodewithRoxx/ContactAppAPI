using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

public class ContactService: IContact
{
	public ContactService()
	{
	}

    private readonly string _filePath = "contacts.json";

    /// <summary>
    /// Get all the contacts
    /// </summary>
    /// <returns></returns>
    public List<Contact> LoadContacts()
	{
        if (!System.IO.File.Exists(_filePath))
        {
            return new List<Contact>();
        }
        var json = System.IO.File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Contact>>(json);
    }

    /// <summary>
    /// Add new contacts
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public Contact CreateContact(Contact contact)
    {
        var contacts = LoadContacts();
        contact.Id = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;
        contacts.Add(contact);
        SaveContacts(contacts);
        return contact;
    }

    /// <summary>
    /// Get contacts by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Contact GetContact(int id)
    {
        var contacts = LoadContacts();
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null) return null;
        return contact;
    }

    /// <summary>
    /// delete the contact by id
    /// </summary>
    /// <param name="id"></param>
    public void DeleteContact(int id)
    {
        var contacts = LoadContacts();
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        
        contacts.Remove(contact);
        SaveContacts(contacts);
        
    }

    /// <summary>
    /// Update the contact
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedContact"></param>
    public void UpdateContact(int id, Contact updatedContact)
    {
        var contacts = LoadContacts();
        var contact = contacts.FirstOrDefault(c => c.Id == id);
       
        contact.FirstName = updatedContact.FirstName;
        contact.LastName = updatedContact.LastName;
        contact.Email = updatedContact.Email;
        SaveContacts(contacts);
    }

    /// <summary>
    /// Save the contacts
    /// </summary>  
    /// <param name="contacts"></param>
    public void SaveContacts(List<Contact> contacts)
    {
        var json = JsonSerializer.Serialize(contacts);
        System.IO.File.WriteAllText(_filePath, json);
    }
}
