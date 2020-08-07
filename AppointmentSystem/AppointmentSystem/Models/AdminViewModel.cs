
using AppointmentSystem.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSystem.Models
{
    public class AdminViewModel
    {

        public AppUser User { get; set; }

        //IEnumerable hafızadaki koleksiyonlar için kullanılır.Yani şöyle anlatıyım aslında bir çok yerde kullandığımız
        //foreach döngüsü üzerinden kullanılmaktadır.Hafızadaki koleksiyonlar diyorum diğer döngüler
        //    içinde olabilir ama hafızadaki koleksiyonlar daha idealdir. 

        //IQueryable ise belli bir uzak veri kaynağından(web service, database) verileri sorgulamak için idealdir.
        public IEnumerable<Appointment> GalleryUsers { get; set; }

        //IList bir interfacedir.IEnurable arayüzlerini referans alır ve bunlardan farklı olarak Insert,RemoveAt
        //    gibi metodları alır.Yani bir interface olduğu için içinde veri saklamaz.
        public IEnumerable<Appointment> Appointment { get; set; }
       
        //internal set ise bir özelliğin değerinin yalnızca aynı derleme içindeki kodla ayarlanmasını sağlayan bir yapıdır diyebiliriz.
        //Diğer programcılar tarafından kullanılmak üzere bir API tasarladığınızı varsayalım.Bu API içinde bir özelliğe sahip
        //bir nesneniz var. Diğer programcıların nesnelerinize başvurduklarında değerini ayarlamasını
        //istemezsiniz  ancak değeri API'nizden kendiniz ayarlamanız gerekir.Yani tam anlatabildim mi bilmiyorum :)
        public IList<SelectListItem> GalleryUsersSelectList { get; internal set; }
        public IList<SelectListItem> CitiesSelectList { get; set; }
}
}
