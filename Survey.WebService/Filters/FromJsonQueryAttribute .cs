using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Survey.WebService.Filters
{
    public class FromJsonQueryIsRequieredAttribute : ModelBinderAttribute
    {
        public FromJsonQueryIsRequieredAttribute()
        {
            BinderType = typeof(JsonQueryBinder);
        }
    }

    public class JsonQueryBinder : IModelBinder
    {
        private readonly IObjectModelValidator _validator;

        public JsonQueryBinder(IObjectModelValidator validator)
        {
            _validator = validator;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.FieldName).FirstValue;
                if (value == null) throw new ArgumentNullException("query param is required");
                var valueParsed = JsonSerializer.Deserialize(
                    value,
                    bindingContext.ModelType,
                    new JsonSerializerOptions(JsonSerializerDefaults.Web)
                );
                bindingContext.Result = ModelBindingResult.Success(valueParsed);
                _validator.Validate(
                    bindingContext.ActionContext,
                    validationState: bindingContext.ValidationState,
                    prefix: string.Empty,
                    model: valueParsed
                );
            }
            catch (ArgumentNullException e)
            {
                bindingContext.ActionContext.ModelState.TryAddModelError
                    ($"'{bindingContext.FieldName}' is a query param requiered", e, bindingContext.ModelMetadata);
            }
            catch(JsonException e)
            {
                bindingContext.ActionContext.ModelState.TryAddModelError
                    ($"'{bindingContext.FieldName}' key query param is waiting a {bindingContext.ModelType} and must be a json string", e, bindingContext.ModelMetadata);
            }

            return Task.CompletedTask;
        }
    }
}
