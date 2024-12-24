using System;
using System.Collections.Generic;

public interface IContact
{
    public List<Contact> LoadContacts();
    public Contact CreateContact(Contact contact);
    public Contact GetContact(int id);
    public void DeleteContact(int id);
    public void UpdateContact(int id, Contact updatedContact);
    public void SaveContacts(List<Contact> contacts);
}
