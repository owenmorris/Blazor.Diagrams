﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Excubo.Blazor.Diagrams
{
    internal static class JSRuntimeExtensions
    {
        private class Position
        {
            public double Left { get; set; }
            public double Top { get; set; }
        }
        private class Dimension
        {
            public double Width { get; set; }
            public double Height { get; set; }
        }
        public static async Task<(double Left, double Top)> GetPositionAsync(this IJSRuntime js, ElementReference element)
        {
            var position = await js.InvokeAsync<Position>("eval", $"let e = document.querySelector('[_bl_{element.Id}=\"\"]'); let r = {{ 'Left': e.offsetLeft, 'Top': e.offsetTop }}; r");
            return (position.Left, position.Top);
        }
        public static async Task<(double Width, double Height)> GetDimensionsAsync(this IJSRuntime js, ElementReference element)
        {
            var dimensions = await js.InvokeAsync<Dimension>("eval", $"let e = document.querySelector('[_bl_{element.Id}=\"\"]'); let r = {{ 'Width': e.clientWidth, 'Height': e.clientHeight }}; r");
            return (dimensions.Width, dimensions.Height);
        }
    }
}
