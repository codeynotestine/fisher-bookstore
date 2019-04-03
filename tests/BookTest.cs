using System;
using Xunit;
using Fisher.Bookstore.Models;

namespace tests
{
    public class BookTest
    {
        [Fact]
        public void ChangePublicationDate()
        {
            //Arrange
            var book = new Book()
            {
                Id = 1,
                Title = "Domain Driven Design",
                Author = new Author()
                {
                    Id = 65,
                    Name = "Eric Evans"
                },
                PublishDate = DateTime.Now.AddMonths(-6),
                Publisher = "McGraw-Hill"
            
            };
           //Act
           var newPublicationDate = DateTime.Now.AddMonths(2);
           book.ChangePublicationDate(newPublicationDate);

           //Assert
           var expectedPublicationDate = newPublicationDate.ToShortDateString();
           var actualPublicationDate = book.PublishDate.ToShortDateString();

           Assert.Equal(expectedPublicationDate, actualPublicationDate);

           //Test to ensure book id is positive
           if (book.Id == 0)
           {
               throw new ArgumentOutOfRangeException("id");
           } 

           if (book.Id < 0)
           {
               throw new ArgumentOutOfRangeException("id");
           }

           //Test to make sure title was inputed
           if (book.Title == null)
           {
               throw new ArgumentOutOfRangeException("Book must have Title");
           }


        }
    }
}
    