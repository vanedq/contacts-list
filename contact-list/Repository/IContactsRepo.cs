using ContactsList.Models;

namespace ContactsList.Repository
{
    public interface IContactsRepo
    {
        ContactsModel Get(int id);
        ContactsModel SaveEdit(ContactsModel contacts);
        List<ContactsModel> GetAll();
        ContactsModel Add(ContactsModel contacts);
        bool DeleteInDb(int id);
    }
}
