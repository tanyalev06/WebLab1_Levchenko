using System;
using System.Collections.Generic;
using System.Text;
using WebLab1_Levchenko.DAL.Entities;
using WebLab1_Levchenko.Models;
using Xunit;

namespace WebLab1_Levchenko.Tests
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Cats>.GetModel(TestData.GetCatsList(), 1, 3);
            // Assert
            Assert.Equal(2, model.TotalPages);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),MemberType = typeof(TestData))]
        public void ListViewModelSelectsCorrectQty(int page, int qty,int id)
        {
           
            // Act
            var model = ListViewModel<Cats>.GetModel(TestData.GetCatsList(), page, 3);
            // Assert
            Assert.Equal(qty, model.Count);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
       MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Cats>.GetModel(TestData.GetCatsList(), page, 3);
            // Assert
            Assert.Equal(id, model[0].CatsID);
        }

    }
}
