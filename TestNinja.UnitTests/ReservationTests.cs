
using NUnit.Framework;
using System;
using System.Reflection;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation() {MadeBy=user };

            //Act
            var result =reservation.CanBeCancelledBy(user); 

            //Assert

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_DifferentUserCancelling_ReturnsFalse() 
        {
            
            var reservation = new Reservation { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

           
            Assert.That(result, Is.False);
        
        }
    }
}
