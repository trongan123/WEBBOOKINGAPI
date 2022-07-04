﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class TransportDAO
    {
        public static List<Transport> getAll()
        {

            List<Transport> list = new List<Transport>();
            using (var context = new ASMBOOKINGContext())
            {
                list = context.Transports.ToList();
            }

            return list;
        }



        public static Transport GetTransportById(string id)
        {
            Transport a = new Transport();
            try
            {
                using (var context = new ASMBOOKINGContext())
                {
                    a = context.Transports.SingleOrDefault(x => x.Idtransport.Equals(id));

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return a;
        }
        public String GetIDCuoi()
        {
            List<Transport> list;

            try
            {
                using (var context = new ASMBOOKINGContext())
                {
                    list = context.Transports.Select((Transport i) => i).ToList();
                    if (list.Count <= 0)
                    {
                        return "T0001";
                    }
                    string iDCuoi = list.Last().Idtransport;
                    return $"T{int.Parse(iDCuoi.Substring(1)) + 1:000#}";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


        public static void AddTransport(Transport a)
        {
            try
            {
                using (var context = new ASMBOOKINGContext())
                {
                    context.Transports.Add(a);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public static void UpdateTransport(Transport a)
        {

            try
            {
                using (var context = new ASMBOOKINGContext())
                {
                    context.Entry<Transport>(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public static void DeleteTransport(Transport a)
        {
            try
            {
                using (var context = new ASMBOOKINGContext())
                {
                    var p1 = context.Transports.SingleOrDefault(
                        x => x.Idtransport == a.Idtransport);
                    if (p1 != null)
                    {
                        context.Transports.Remove(p1);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
