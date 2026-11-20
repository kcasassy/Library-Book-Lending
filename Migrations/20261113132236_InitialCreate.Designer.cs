
using Library_Book_Lending.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Book_Lending.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20261113132236_InitialCreate")]
    public partial class InitialCreate
    {
    }
}
