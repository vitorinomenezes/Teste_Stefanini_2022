using Microsoft.AspNetCore.Mvc;

namespace Api
{
    public interface InterfaceController<T> where T : class
    {
        Task<IActionResult> Index(int? id);

        Task<IActionResult> Form(int? id);

        Task<IActionResult> Save(int id, T _model);

        bool ModelExists(int id);

        Task<IActionResult> Delete(int id);


    }
}
