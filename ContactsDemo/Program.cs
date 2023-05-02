using System.Text.Json;
using ContactsDemo.Model;

/*
 * CRUD
 *   - Create
 *   - Read
 *   - Update
 *   - Delete
 */

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var contacts = new List<Contact>();


app.MapGet("/contacts", () =>
{
    return GetAllContacts();
});
app.MapPost("/contacts", (Contact contact) =>
{
    var contacts = GetAllContacts();
    contacts.Add(contact);
    SaveAllContacts(contacts);
});
app.MapDelete("/contacts/{id}", (string id) =>
{
    var contacts = GetAllContacts();
    var index = contacts.FindIndex(c => c.Id == id);
    if (index == -1) return false;
    contacts.RemoveAt(index);
    SaveAllContacts(contacts);
    return true;
});
app.MapPut("/contacts", (Contact contactFromFrontend) =>
{
    var contacts = GetAllContacts();
    var contact = contacts.Find(c => c.Id == contactFromFrontend.Id);
    contact.FirstName = contactFromFrontend.FirstName;
    contact.Email = contactFromFrontend.Email;
    SaveAllContacts(contacts);
});
//app.MapGet("/contacts", () =>
//{
//    return contacts;
//});
//app.MapPost("/contacts", (Contact contact) =>
//{
//    contacts.Add(contact);
//});
//app.MapDelete("/contacts/{id}", (string id) =>
//{
//    var index = contacts.FindIndex(c=>c.Id==id);
//    if (index == -1) return false;
//    contacts.RemoveAt(index);
//    return true;
//});
//app.MapPut("/contacts", (Contact contactFromFrontend) =>
//{
//    var contact = contacts.Find(c => c.Id == contactFromFrontend.Id);
//    contact.FirstName = contactFromFrontend.FirstName;
//    contact.Email = contactFromFrontend.Email;
//});
app.Run();

List<Contact> GetAllContacts()
{
    if (!File.Exists("contacts.json")) return new List<Contact>();
    var json = File.ReadAllText("contacts.json");
    return JsonSerializer.Deserialize<List<Contact>>(json);
}

void SaveAllContacts(List<Contact> contacts)
{
    var json = JsonSerializer.Serialize(contacts);
    File.WriteAllText("contacts.json", json);
}




