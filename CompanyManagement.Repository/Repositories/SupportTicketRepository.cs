using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Datas.Concrete
{
    public class SupportTicketRepository: ISupportTicketRepository
    {
        public readonly IDatabaseContext _idb_context;
        public SupportTicketRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }


        //---------------------Save Update Attendance------------------------------- 


        public Response SaveUpdate(SupportTicketModel modal, DataTable dt)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@SupportTicketID", modal.SupportTicketID);
                parameters.Add("@SupportTicketDetail", modal.SupportTicketDetailId);
                parameters.Add("@FranchiseId", modal.CreatedBy);
                parameters.Add("@TicketSubject", modal.TicketSubject);
                parameters.Add("@TicketStatusId", modal.TicketStatusId);
                parameters.Add("@TicketPriorityID", modal.TicketPriorityID);
                parameters.Add("@TicketDetail", modal.TicketDetail);
                parameters.Add("@CreatedBy", modal.CreatedBy);
                parameters.Add("@IsComment",true);
                parameters.Add("@AttachmentFile", dt, DbType.Object, null, -1);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                var result = _idb_context.Query<string>("SaveUpdateTickets", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }

            }
            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (DataException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response;

        }


        //----------------------------- Get All status/priority------------------------ 

        public SupportStatusPriorityList GetStatusPriority()
        {
            SupportStatusPriorityList report = new SupportStatusPriorityList();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                
                using (var multi = _idb_context.QueryMultiple("GetPriorityStatus", parameters, null, CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed)
                    {
                        report.TicketPriorityList = (List<SupportTicketPriority>)multi.Read<SupportTicketPriority>();
                    }
                    if (!multi.IsConsumed)
                    {
                        report.SupportStatusList = (List<SupportTicketStatus>)multi.Read<SupportTicketStatus>();
                    }

                }
            }
            catch (SqlException ex)
            {
               // report.Status = (int)ErrorStatus.Exception;
               // report.Message = ex.Message;
            }
            catch (DataException ex)
            {
               // report.Status = (int)ErrorStatus.Exception;
               // report.Message = ex.Message;
            }
            catch (Exception ex)
            {
              //  report.Status = (int)ErrorStatus.Exception;
                //report.Message = ex.Message;
            }
            return report;
        }

        //----------------------------- Get All GetAllTickets------------------------ 

        public SupportFetchList GetAllTickets(string userID)
        {
            SupportFetchList report = new SupportFetchList();
            try
            {
                var split = userID.Split('-');
                var usertypeId = split[1].Split(':');
                var userId = split[0].Split(':');
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@FranchiseID", Int32.Parse(userId[1]));
              
                if (Int32.Parse(usertypeId[1]) == 1)
                {

                    using (var multi = _idb_context.QueryMultiple("SupportTicketDev", parameters, null, CommandType.StoredProcedure))
                    {
                        report.FetchTicketList = multi.Read<TicketLIST>().ToList();

                        if (!multi.IsConsumed) // Optional, but only if you're unsure
                            report.fatchTicketAttachmentList = multi.Read<TicketAttachmentList>().ToList();
                    }

                }
                else
                {

                    using (var multi = _idb_context.QueryMultiple("SupportTicketFatch", parameters, null, CommandType.StoredProcedure))
                    {
                        if (!multi.IsConsumed)
                        {
                            report.FetchTicketList = (List<TicketLIST>)multi.Read<TicketLIST>();
                        }
                        if (!multi.IsConsumed)
                        {
                            report.fatchTicketAttachmentList = (List<TicketAttachmentList>)multi.Read<TicketAttachmentList>();
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                 report.Status = (int)ErrorStatus.Exception;
                 report.Message = ex.Message;
            }
            catch (DataException ex)
            {
                 report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (Exception ex)
            {
                  report.Status = (int)ErrorStatus.Exception;
               report.Message = ex.Message;
            }
            return report;
        }


        //----------------------------- Get All single------------------------ 

        public  SupportFetchList GetSingle(string ticketID)
        {
            SupportFetchList report = new SupportFetchList();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@TicketID", ticketID);




                using (var multi = _idb_context.QueryMultiple("SupportTicketSingleFatch", parameters, null, CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed)
                    {
                        report.FetchTicketList = (List<TicketLIST>)multi.Read<TicketLIST>();
                    }
                    if (!multi.IsConsumed)
                    {
                        report.fatchTicketAttachmentList = (List<TicketAttachmentList>)multi.Read<TicketAttachmentList>();
                    }

                }
            }
            catch (SqlException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (DataException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (Exception ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            return report;
        }
       


    }
}
