using FileStatusCheckerAPI.DTO;
using FileStatusCheckerApplication.FileChecker;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace FileStatusCheckerAPI.Controllers
{
    public class DirectoryController : Controller
    {
        private readonly IFileService _fileService;

        public DirectoryController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("Directory")]
        //public ActionResult SetFileDirectory([FromBody] DirectoryInputDTO directory)
        public ActionResult SetFileDirectory(string directory)
        {
            _fileService.SaveHistoricalFile(directory);
            return Ok();
        }

        [HttpGet("FileCheck/{directory}")]
        public ActionResult CheckIfFileChanged(string directory)
        {
            var result = _fileService.CheckIfFilesChanged(directory);
            List<FilesChangedDTO> final = result.Select(n => new FilesChangedDTO() { 
                FilePath = n.FilePath,
                Action = n.Action.GetDisplayName(),
                Version = n.Version}).ToList();
                
            return Ok(final);
        }
    }
}
