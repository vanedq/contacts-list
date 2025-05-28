using ContactsList.Models;

namespace ContactsList.Repository
{
    public class ContactsRepo : IContactsRepo
    {
        private readonly Data.Db _db;
        public ContactsRepo(Data.Db db) {
            _db = db;
        }
        public ContactsModel Add(ContactsModel contacts)
        {
            _db.Contacts.Add(contacts);
            _db.SaveChanges(); //commit
            return contacts;
        }

        public ContactsModel Get(int id)
        {
            return _db.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public ContactsModel SaveEdit(ContactsModel contacts)
        {
            ContactsModel existingContact = Get(contacts.Id);
            if (existingContact == null) throw new Exception("Contact not found");

                existingContact.Name = contacts.Name;
                existingContact.Email = contacts.Email;
                existingContact.Phone = contacts.Phone;
                _db.SaveChanges();

            return existingContact;
        }

        public List<ContactsModel> GetAll()
        {
            return _db.Contacts.ToList();
        }

        public bool DeleteInDb(int id)
        {

            ContactsModel existingContact = Get(id);
            if (existingContact == null) throw new Exception("Error while trying to delete. Contact not found.");

            _db.Contacts.Remove(existingContact);
            _db.SaveChanges();

            return true;
        }
    }
}
