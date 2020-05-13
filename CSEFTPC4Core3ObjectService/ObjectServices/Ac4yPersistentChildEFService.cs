
using CSEFTPC4Core3Cap.CAPs;
using CSEFTPC4Core3Objects.Ac4yObjects;
using Modul.Final.Class;
using System;

namespace CSEFTPC4Core3ObjectService.ObjectServices
{
 
    public class Ac4yPersistentChildEFService
    {
        public GetByIdResponse GetById(GetByIdRequest request)
        {

            GetByIdResponse response = new GetByIdResponse();

            try
            {

                response.Ac4yPersistentChild = new Ac4yPersistentChildEFCap().GetById(request.Id);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // GetById

        public GetByGuidResponse GetByGuid(GetByGuidRequest request)
        {

            GetByGuidResponse response = new GetByGuidResponse();

            try
            {

                response.Ac4yPersistentChild = new Ac4yPersistentChildEFCap().GetByGuid(request.Guid);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // GetByGuid

        public IsExistByIdResponse IsExistById(IsExistByIdRequest request)
        {
            IsExistByIdResponse response = new IsExistByIdResponse();

            try
            {

                if (new Ac4yPersistentChildEFCap().IsExistById(request.Id))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // IsExistById

        public IsExistByGuidResponse IsExistByGuid(IsExistByGuidRequest request)
        {

            IsExistByGuidResponse response = new IsExistByGuidResponse();

            try
            {

                if (new Ac4yPersistentChildEFCap().IsExistByGuid(request.Guid))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // IsExistByGuid

        public UpdateByIdResponse UpdateById(UpdateByIdRequest request)
        {

            UpdateByIdResponse response = new UpdateByIdResponse();

            try
            {

                new Ac4yPersistentChildEFCap().UpdateById(request.Id, request.Ac4yPersistentChild);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // UpdateById

        public UpdateByGuidResponse UpdateByGuid(UpdateByGuidRequest request)
        {

            UpdateByGuidResponse response = new UpdateByGuidResponse();

            try
            {

                new Ac4yPersistentChildEFCap().UpdateByGuid(request.Guid, request.Ac4yPersistentChild);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // UpdateByGuid

        public InsertResponse Insert(InsertRequest request)
        {

            InsertResponse response = new InsertResponse();

            try
            {

                new Ac4yPersistentChildEFCap().Insert(request.Ac4yPersistentChild);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // Insert

        public SetByGuidResponse SetByGuid(SetByGuidRequest request)
        {

            SetByGuidResponse response = new SetByGuidResponse();

            try
            {

              IsExistByGuidResponse isExistByGuidResponse =
                  IsExistByGuid(new IsExistByGuidRequest() { Guid = request.Guid } );

              if (isExistByGuidResponse.Result.Success())
              {

                  UpdateByGuidResponse updateByGuidResponse =
                      UpdateByGuid(
                          new UpdateByGuidRequest()
                          {
                              Guid = request.Guid
                              ,
                              Ac4yPersistentChild = request.Ac4yPersistentChild
                          });

                  response.Result = updateByGuidResponse.Result;

              }
              else
              {

                  InsertResponse insertResponse =
                      Insert(
                          new InsertRequest()
                          {
                              Ac4yPersistentChild = request.Ac4yPersistentChild
                          });

                  response.Result = insertResponse.Result;

              }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // SetByGuid
        public class GetByIdRequest : Ac4yServiceRequest
        {
            public int Id { get; set; }
        }

        public class GetByIdResponse : Ac4yServiceResponse
        {
            public Ac4yPersistentChild Ac4yPersistentChild { get; set; }
        }

        public class GetByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
        }

        public class GetByGuidResponse : Ac4yServiceResponse
        {
            public Ac4yPersistentChild Ac4yPersistentChild { get; set; }
        }

        public class IsExistByIdRequest : Ac4yServiceRequest
        {
            public int Id { get; set; }
        }

        public class IsExistByIdResponse : Ac4yServiceResponse {}

        public class IsExistByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
        }

        public class IsExistByGuidResponse : Ac4yServiceResponse {}

        public class UpdateByIdRequest : Ac4yServiceRequest
        {
            public int Id { get; set; }
            public Ac4yPersistentChild Ac4yPersistentChild { get; set; }
        }

        public class UpdateByIdResponse : Ac4yServiceResponse {}

        public class UpdateByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
            public Ac4yPersistentChild Ac4yPersistentChild { get; set; }
        }

        public class UpdateByGuidResponse : Ac4yServiceResponse {}

        public class InsertRequest : Ac4yServiceRequest
        {
            public Ac4yPersistentChild Ac4yPersistentChild { get; set; }
        }

        public class InsertResponse : Ac4yServiceResponse {}

        public class SetByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
            public Ac4yPersistentChild Ac4yPersistentChild { get; set; }
        }

        public class SetByGuidResponse : Ac4yServiceResponse {}

    } // Ac4yPersistentChildEFService

} // EFService
