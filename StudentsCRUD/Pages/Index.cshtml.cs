using StudentsCRUD.Services;
using StudentsCRUD.Services.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace StudentsCRUD.Pages;

public class IndexModel : AbpPageModel
{
    public List<StudentDto>Students { get; set; }

    private readonly StudentAppService _studentAppService;

    public IndexModel(StudentAppService studentAppService)
    {
        _studentAppService = studentAppService;
    }

    

    public async Task OnGetAsync()
    {
        Students = await _studentAppService.GetAll();
    }
}