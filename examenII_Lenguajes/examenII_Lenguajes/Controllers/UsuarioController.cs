using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using examenII_Lenguajes;
using System.Web.Helpers;//para encriptar la contraseña
using System.Web.Security;//seguridad a nivel asp

namespace examenII_Lenguajes.Controllers
{
    public class UsuarioController : Controller
    {
        private DBExamenContext1 db = new DBExamenContext1();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(db.tbUsuario.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuario.Find(id);
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuario);
        }

        // GET: Usuario/Create
        public ActionResult Registro()
        {
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro([Bind(Include = "idUsuario,email,password,nombre,direccion,telefono")] tbUsuario tbUsuario)
        {
            if (ModelState.IsValid)
            {
                db.tbUsuario.Add(tbUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbUsuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuario.Find(id);
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,email,password,nombre,direccion,telefono")] tbUsuario tbUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbUsuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuario.Find(id);
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbUsuario tbUsuario = db.tbUsuario.Find(id);
            db.tbUsuario.Remove(tbUsuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]//ejecuta la solicitud del usuario
        public ActionResult Logeo()//se cambia lo que dice index por que ocupamos
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logeo(tbUsuario user, String retornarUrl)
        {
            if (ModelState.IsValid)
            {
                if (mValidarAcceso(user.email, user.password))
                {

                    //Gestiona la verificacion en la autenticacion del formulario
                    FormsAuthentication.SetAuthCookie(user.email, user.RememberMe);//crea la autenticacion del correo y lo agrega a las cookies

                    if (Url.IsLocalUrl(retornarUrl) && retornarUrl.Length > 1 && retornarUrl.StartsWith("/")
                        && !retornarUrl.StartsWith("//") && !retornarUrl.StartsWith("/\\"))
                    {
                        return Redirect(retornarUrl);
                    }//fin del if

                    else
                    {
                        return RedirectToAction("Index","Home");

                    }//fin del else

                }//fin del mValidarAcceso

                else
                {
                    ModelState.AddModelError("", "El usuario o la contraseña no existe");//para mostrar mensajes

                }//fin del else de la validacion

            }//fin  del isvalid

            return View(user);

        }//fin del metodo Logeo 


        public bool mValidarAcceso(String email, String password)
        {
            String encriptado;
            bool retorno = false;

            using (var db = new DBExamenContext1())
            {
                var user = db.tbUsuario.FirstOrDefault(u => u.email == email);//primero entra el campo de la tabla y luego el parametro
                if (user != null)
                {
                    encriptado = user.password;

                    if (Crypto.VerifyHashedPassword(encriptado, password) == true)
                    {
                        retorno = true;
                    }//fin del if de Crypto

                }//fin del if del null

            }//fin del using
            return retorno;

        }//fin del metodo validarDatos
    }
}
