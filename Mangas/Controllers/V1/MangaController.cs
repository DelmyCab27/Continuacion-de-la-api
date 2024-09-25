using AutoMapper;
using manga.Domain.Dtos;
using mangas.Domain.Entities;
using mangas.Services.Features.Mangas;
using Microsoft.AspNetCore.Mvc;

namespace mangas.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class MangaController : ControllerBase
{
    public readonly MangaService _mangaService;

   private readonly IMapper _mapper;

   public MangaController(MangaService mangaService, IMapper mapper)
   {
     this._mangaService = mangaService;
     this._mapper = mapper;
   }

    [HttpGet]
    public IActionResult GetAll()
    {
        var mangas = _mangaService.GetAll();
        var mangaDtos = _mapper.Map<IEnumerable<MangaDTO>>(mangas);
        return Ok(mangaDtos);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var manga = _mangaService.GetById(id);
        if (manga.Id <= 0)
            return NotFound();

        var dto = _mapper.Map<MangaDTO>(manga);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Manga manga)
    {
        var entity = _mapper.Map<Manga>(manga);
        var mangas = _mangaService.GetAll();
        var mangaId = mangas.Count() + 1;

        entity.Id = mangaId;
        _mangaService.Add(entity);

        var dto = _mapper.Map<MangaDTO>(entity);
        return CreatedAtAction (nameof(GetById), new { id = entity.Id }, dto);
    }

    [HttpPut("{id}")]
public IActionResult Update(int id, [FromBody] MangaUpdateDTO mangaUpdateDto)
{
    // Obtener el manga existente desde el servicio o repositorio
    var existingManga = _mangaService.GetById(id);
    if (existingManga == null)
        return NotFound();

    // Mapear los datos del DTO al objeto Manga existente
    _mapper.Map(mangaUpdateDto, existingManga);

    // Actualizar el objeto Manga en la base de datos
    _mangaService.Update(existingManga);

    return NoContent();
}

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _mangaService.Delete(id);
        return NoContent();
    }
}
