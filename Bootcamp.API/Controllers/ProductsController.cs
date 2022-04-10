﻿using Bootcamp.API.Commands;
using Bootcamp.API.Commands.ProductDelete;
using Bootcamp.API.Queries;
using Bootcamp.API.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{

    public class ProductsController : ControllerCustomBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response = await _mediator.Send(new ProductGetAllQuery());

            return CreateActionResult(response);

        }

        [HttpGet("pages/{page}/{pagesize}")]
        public async Task<IActionResult> GetAllWithPage(int page, int pagesize)
        {

            var response = await _mediator.Send(new ProductWithPageQuery() { Page = page, PageSize = pagesize });

            return CreateActionResult(response);

        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductInsertCommand productInsertCommand)
        {

            return CreateActionResult(await _mediator.Send(productInsertCommand));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateCommmand productUpdateCommmand)
        {

            return CreateActionResult(await _mediator.Send(productUpdateCommmand));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            return CreateActionResult(await _mediator.Send(new ProductDeleteCommand() { Id = id }));
        }
    }
}
