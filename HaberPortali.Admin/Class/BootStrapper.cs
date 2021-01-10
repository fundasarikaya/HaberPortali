using Autofac;
using Autofac.Integration.Mvc;
using HaberPortali.Core.Infrastructure;
using HaberPortali.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortali.Admin.Class
{
    public class BootStrapper
    {
        //boot aşamasında calışacak
        //aşagıdaki buildautofac metodunu yazdıktan sonra runconfig metodu yazarız
        public static void RunConfig()
        {
            BuildAutoFac();
        }
        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();
            //bu kısımları yazdıktan sonra core da repository işlemlerini gercekleştirdik interfaceleri falan
            //sonra haberportali.adminin references sag tık add references projects Haberportali.core ve .data ları ekledik
            //daha sonra yorum olak * belirttiklerim referans ve interface işlemlerinden sonra yazıldı

            builder.RegisterType<HaberRepository>().As<IHaberRepository>(); //*
            builder.RegisterType<ResimRepository>().As<IResimRepository>(); //*
            builder.RegisterType<UserRepository>().As<IUserRepository>(); //*
            builder.RegisterType<RolRepository>().As<IRolRepository>(); //*
            //buradan sonra controllera home controller ekliyoruz
            builder.RegisterType<KategoriRepository>().As<IKategoriRepository>();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //buraya core katmanında oluşturacagımız interfaceleri ekleriz
            //buraya register etmedigimiz seyler calışmaz
            //burdan global.asax kısmına gectik


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}