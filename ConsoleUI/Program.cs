using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
ColorManager colorManager = new ColorManager(new EfColorDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());
UserManager userManager = new UserManager(new EfUserDal());
CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
RentalManager rentalManager = new RentalManager(new EfRentalDal());

var result = colorManager.GetColorById(1);

Console.WriteLine(result.Data.Name);

void deleteRental()
{
    var result = rentalManager.Delete(new Rental { Id = 1 });

    if (result.IsSuccess)
    {
        Console.WriteLine(result.Message);
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}



void addRental()
{
    var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 3, RentDate = DateTime.Now });
    Console.WriteLine(result.Message);
}

void getRentals()
{
    foreach (var rental in rentalManager.GetAll().Data)
    {
        Console.WriteLine(rental.RentDate);
    }
}

void getCustomers()
{
    foreach (var customer in customerManager.GetAll().Data)
    {
        Console.WriteLine(customer.CompanyName);
    }
}

void addCustomer()
{
    customerManager.Add(new Customer { UserId = 3, CompanyName = "flutter" });
}

void addUser()
{
    userManager.Add(new User { FirstName = "Yusuf", LastName = "Keçer", Email = "12345@gmail.com", Password = "12345" });
}

void getUsers()
{
    foreach (var user in userManager.GetAll().Data)
    {
        Console.WriteLine(user.FirstName);
    }
}

void getCarDetails()
{
    foreach (var car in carManager.GetCarDetails().Data)
    {
        Console.WriteLine(car.Description + " / " + car.BrandName + " / " + car.ColorName);
    }
}

void updateCarWithError()
{
    var result = carManager.Update(new Car { Id = -1 });

    Console.WriteLine(result.Message);
}


void getBrands()
{
    //foreach (var brand in brandManager.GetAll())
    //{
    //    Console.WriteLine(brand.Name);
    //}
}

void addColor()
{
    colorManager.Add(new Color { Name = "Grey" });
}

void getColors()
{
    foreach (var color in colorManager.GetAll().Data)
    {
        Console.WriteLine(color.Name);
    }

    Console.WriteLine("\n");
}

void updateCar()
{
    carManager.Update(new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 120, ModelYear = "2012", Description = "Mazda RX-8" });
}

void getCars()
{
    foreach (var car in carManager.GetAll().Data)
    {
        Console.WriteLine(car.Description);
    }

    Console.WriteLine("\n");
}

void getCarsByBrandId()
{
    //foreach (var car in carManager.GetAllByBrandId(2))
    //{
    //    Console.WriteLine(car.Description);
    //}

    //Console.WriteLine("\n");

}

void getCarsByColorId()
{
    //foreach (var car in carManager.GetAllByColorId(1))
    //{
    //    Console.WriteLine(car.Description);
    //}

    //Console.WriteLine("\n");

}

void addCar()
{
    //Veri tabanına insert işlemi
    //carManager.Add(new Car { BrandId = 3, ColorId = 1, DailyPrice = 1500, Description = "Porsche 918 Spyder", ModelYear="2014" });

    //foreach (var car in carManager.GetAll())
    //{
    //    Console.WriteLine(car.Description);
    //}
}

void deleteCar()
{
    //Veri tabanına delete işlemi
    //carManager.Delete(new Car { Id = 3});

    //Console.WriteLine("\n");

    //foreach (var car in carManager.GetAll())
    //{
    //    Console.WriteLine(car.Description);
    //}
}