using Lab3.DataStorage;
using Lab3.Task;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly DataStorage _dataStorage;

    public TasksController(DataStorage dataStorage)
    {
        _dataStorage = dataStorage;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetFromSqlite()
    {
        var tasks = _dataStorage.LoadFromSQLite();
        return Ok(tasks);
    }

    [HttpPost]
    public ActionResult PostToSqlite([FromBody] List<TaskItem> tasks)
    {
        _dataStorage.SaveToSQLite(tasks);
        return Ok();
    }
}