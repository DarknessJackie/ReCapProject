﻿using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

            //var results = _rentalDal.GetAll(p => p.CarId == rental.CarId);

            //foreach (var item in results)
            //{
            //    if (item != null)
            //    {
            //        var date = DateTime.Compare(rental.ReturnDate, item.ReturnDate); // soldaki tarih sağdakinden geçmişteyse değeri 0'dan küçüktür
            //        if (date < 0)
            //        {
            //            return new ErrorResult(Messages.RentalNoAdded);
            //        }
            //    }
            //}
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDto>> GetAllRentalDtos()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetRentalDtos());
        }

        public IDataResult<RentalDto> GetRentalDto(int id)
        {
            return new SuccessDataResult<RentalDto>(_rentalDal.GetRentalDto(id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
