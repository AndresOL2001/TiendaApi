using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace TiendaApi.Helpers
{
    public class ModelBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nombreDeLaPropiedad = bindingContext.ModelName;

            var proveedorDeValores = bindingContext.ValueProvider.GetValue(nombreDeLaPropiedad);

            if (proveedorDeValores == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            try
            {
                var valorDeserealizado = JsonConvert.DeserializeObject<T>(proveedorDeValores.FirstValue);

                bindingContext.Result = ModelBindingResult.Success(valorDeserealizado);
            }catch (Exception ex)
            {
                bindingContext.ModelState.TryAddModelError(nombreDeLaPropiedad, "Valor invalido para el listado");
            }
            return Task.CompletedTask;
        }
    }
}
