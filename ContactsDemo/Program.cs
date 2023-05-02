using ContactsDemo.Model;

/*
 * CRUD
 *   - Create
 *   - Read
 *   - Update
 *   - Delete
 */
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
var contacts = new List<Contact>
{
    new Contact("1", "Per", "per@mail.com"),
    new Contact("2", "Pål", "paa@mail.com"),
};

app.MapGet("/contacts", () =>
{
    return contacts;
});
app.MapPost("/contacts", (Contact contact) =>
{
    contacts.Add(contact);
});
app.MapDelete("/contacts/{@id}", (string id) =>
{
    var index = contacts.FindIndex(c=>c.Id==id);
    contacts.RemoveAt(index);
});
app.Run();






//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}