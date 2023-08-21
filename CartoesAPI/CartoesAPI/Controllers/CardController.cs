using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using CartoesAPI.Data;
using CartoesAPI.Data.Dtos;
using CartoesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CartoesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private CardContext _context;
        private IMapper _mapper;

        public CardController(CardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCard([FromBody] CreateCardDto cardDto)
        {
            Card card = _mapper.Map<Card>(cardDto);
            _context.Cards.Add(card);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCardById), new { Id = card.Id }, card);
        }

        [HttpGet]
        public IEnumerable<Card> GetCards()
        {
            return _context.Cards;
        }

        [HttpGet("{id}")]
        public IActionResult GetCardById(int id)
        {
            Card card = _context.Cards.FirstOrDefault(card => card.Id == id);
            if (card != null)
            {
                ReadCardDto movieDto = _mapper.Map<ReadCardDto>(card);
                return Ok(movieDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCard(int id, [FromBody] UpdateCardDto cardDto)
        {
            Card card = _context.Cards.FirstOrDefault(card => card.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            _mapper.Map(cardDto, card);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            Card card = _context.Cards.FirstOrDefault(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            _context.Remove(card);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

