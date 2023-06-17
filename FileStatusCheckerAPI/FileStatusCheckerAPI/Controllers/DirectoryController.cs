using FileStatusCheckerAPI.DTO;
using FileStatusCheckerApplication.FileChecker;
using FileStatusCheckerApplication.TempFileOperators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileStatusCheckerAPI.Controllers
{
    public class DirectoryController : Controller
    {
        private readonly IFileDirectionRepository _directionRepository;
        private readonly IFileService _fileService;

        public DirectoryController(IFileDirectionRepository directionRepository, IFileService fileService)
        {
            _directionRepository = directionRepository;
            _fileService = fileService;
        }

        [HttpPost("Directory")]
        public ActionResult SetFileDirectory([FromBody] DirectoryInputDTO directory)
        {
            _fileService.SaveHistoricalFile(directory.Directory);
            return Ok();
        }

        [HttpGet("FileCheck")]
        public ActionResult CheckIfFileChanged()
        {
            var result = _fileService.CheckIfFilesChanged();
            List<FilesChangedDTO> final = result.Select(n => new FilesChangedDTO() { FilePath = n.Key, Action = n.Value }).ToList();
                
            return Ok(final);
        }
    }
}
