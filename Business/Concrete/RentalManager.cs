﻿using Business.Abstract;
using Business.Constans;
using Core.Ultilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {

            var results = _rentalDal.GetAll(p => p.CarId == rental.CarId);

            bool success = true;

            foreach (var item in results)
            {
                if (item != null)
                {
                    var date = DateTime.Compare(rental.ReturnDate, item.ReturnDate); // soldaki tarih sağdakinden geçmişteyse değeri 0'dan küçüktür
                    if (date < 0)
                    {
                        success = false;
                    }
                }
            }

            if (success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }

            else
            {
                return new ErrorResult(Messages.RentolNoAdded);
            }

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p=>p.Id==id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}