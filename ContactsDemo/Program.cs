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
app.Run();






//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}