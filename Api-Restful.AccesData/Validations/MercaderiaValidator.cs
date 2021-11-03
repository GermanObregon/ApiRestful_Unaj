


using Api_Restful.AccesData.Queries.Repository;
using Api_Restful.Domain.DTO_s;
using FluentValidation;


namespace Api_Restful.AccesData.Validations
{
    public class MercaderiaValidator : AbstractValidator<MercaderiaDto>
    {
        private readonly IMercaderiaQuery _query;
        public MercaderiaValidator(IMercaderiaQuery query)
        {
            _query = query;
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre no puede estar vacio.");
            RuleFor(x => x.Nombre).MaximumLength(50).WithMessage("El nombre debe tener menos de 50 caracteres.");

            RuleFor(x => x.Ingredientes).NotEmpty().WithMessage("Los ingredientes no puede estar vacio.");
            RuleFor(x => x.Ingredientes).MaximumLength(255).WithMessage("El nombre debe tener menos de 255 caracteres.");

            RuleFor(x => x.Imagen).NotEmpty().WithMessage("La Imagen no puede estar vacia.");
            RuleFor(x => x.Imagen).MaximumLength(255).WithMessage("La Imagne debe tener menos de 255 caracteres.");

            RuleFor(x => x.Preparacion).NotEmpty().WithMessage("La Preparacion no puede estar vacia.");
            RuleFor(x => x.Preparacion).MaximumLength(255).WithMessage("La Preparacion debe tener menos de 255 caracteres.}");

            RuleFor(x => x.Precio).GreaterThan(0).WithMessage("El precio debe ser mayor que cero.");
            RuleFor(x => x.Precio).NotNull().WithMessage("Debe Ingresar un Numero");

            int cantidad = _query.GetCantidadTipos().Cantidad;
            RuleFor(x => x.TipoMercaderiaId).LessThan(cantidad).WithMessage("No existe ese tipoMercaderiaId")
                .GreaterThan(0).WithMessage("El TipoMercaderiaId no puede ser menor ni igual a cero.");

        }
    }
}
