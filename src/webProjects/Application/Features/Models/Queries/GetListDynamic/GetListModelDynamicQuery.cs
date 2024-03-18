using Amazon.Runtime.Internal;
using Application.Features.Models.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetListDynamic;

public class GetListModelDynamicQuery:IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}
