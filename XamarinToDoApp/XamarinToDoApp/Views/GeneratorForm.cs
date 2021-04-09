using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using XamarinToDoApp.Attribute;

namespace XamarinToDoApp.Pages
{
    public class GeneratorForm<T> where T : class
    {
        //generate form by Model
        private Dictionary<int, DtoForm> IndexToElement = new Dictionary<int, DtoForm>();
        public delegate void OnSubmit(T model);
        public event OnSubmit Notify;
        private T model;

        public GeneratorForm(T model)
        {
            this.model = model;
            var properties = model.GetType().GetProperties();

            var propName = properties.Select(x =>
            {
                var prop = x.GetCustomAttribute<XamarinFormComponentAttribute>();
                return new DtoForm
                {
                    Name = x.Name,
                    ElType = prop.ComponentName,
                    IsPassword = prop.IsPassword
                };
            }).ToList();
            for (int i = 0; i < propName.Count; i++)
            {
                IndexToElement.Add(i + 1, propName[i]);
            }

        }

        public View Generate()
        {
            var grid = new Grid
            {
                Margin = new Thickness(20, 0, 20, 0),
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            for (int i = 0; i < IndexToElement.Count + 2; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            //for validation error
            var validationError = new Label { FontSize = 16, TextColor = Color.Red, Margin = new Thickness(20, 0, 20, 0) };
            grid.Children.Add(validationError, 0, 0);

            //model properties
            for (int i = 1; i < IndexToElement.Count + 1; i++)
            {
                var el = IndexToElement[i];
                if (el.ElType == "Entry")
                {
                    grid.Children.Add(new Entry { FontSize = 16, Placeholder = el.Name, IsPassword = el.IsPassword, Margin = new Thickness(20, 0, 20, 0) }, 0, i);
                }
                else if (el.ElType == "Editor")
                {
                    grid.Children.Add(new Editor { HeightRequest = 100, FontSize = 16, Placeholder = el.Name, Margin = new Thickness(20, 0, 20, 0) }, 0, i);
                }
            }
            Button button = new Button() { Text = "Register", FontSize = 16, Margin = new Thickness(20, 0, 20, 0) };

            //submit button
            grid.Children.Add(button, 0, IndexToElement.Count + 1);

            button.Clicked += (s, e) => Button_Click(s, e, model);

            StackLayout stackLayout = new StackLayout
            {
                Children = { grid }
            };

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;

            return stackLayout;
        }

        private void Button_Click(object sender, EventArgs e, T model)
        {
            Button button = (Button)sender;
            var grid = (Grid)button.Parent;

            var child = grid.Children;

            foreach (var item in IndexToElement)
            {
                model.GetType().GetProperty(item.Value.Name, BindingFlags.Public | BindingFlags.Instance).SetValue(model, ((InputView)grid.Children[item.Key]).Text);
            }

            //validation
            var valErr = (Label)grid.Children[0];
            valErr.Text = string.Empty;

            ValidationContext context = new ValidationContext(model, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(model, context, validationResults, true);
            if (!valid)
            {
                valErr.Text = string.Join("\n", validationResults.Select(x => x.ErrorMessage).ToList());
            }
            else
            {
                Notify.Invoke(model);
            }
        }


        private class DtoForm
        {
            public string Name { get; set; }
            public string ElType { get; set; }
            public bool IsPassword { get; set; }
        }
    }
}
