using System.Diagnostics;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

public class EmailController : Controller
{
    private readonly EmailService _emailService;

    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    public IActionResult EnqueueEmail()
    {
        // Encola el trabajo de envío de correo en segundo plano
        BackgroundJob.Enqueue(() => _emailService.SendEmail("destinatario@example.com", "Asunto del correo", "Cuerpo del correo"));

        // Puedes redirigir a una vista o a donde desees después de encolar el trabajo.
        return RedirectToAction("Email", "Email");
    }
}
