using System;
using System.Collections.Generic;
using Docnet.Core.Converters;
using Docnet.Core.Models;

namespace Docnet.Core.Readers
{
    public interface IPageReader : IDisposable
    {
        /// <summary>
        /// Gets page index.
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Get scaled page width.
        /// </summary>
        int GetPageWidth();

        /// <summary>
        /// Get scaled page high.
        /// </summary>
        int GetPageHeight();

        /// <summary>
        /// Get page text.
        /// </summary>
        string GetText();

        /// <summary>
        /// Get all page characters refs.
        /// </summary>
        IEnumerable<CharacterRef> GetCharacterRefs();

        /// <summary>
        /// Get all page characters with
        /// their bounding boxes.
        /// </summary>
        IEnumerable<Character> GetCharacters();

        /// <summary>
        /// Convert a PdfPoint, in PDF
        /// coordinates to Point in pixel
        /// coordinates.
        /// </summary>
        Point GetAdjustedPoint(PdfPoint point);

        /// <summary>
        /// Convert a PdfBoundBox, in PDF
        /// coordinates to BoundBox in
        /// pixel coordinates.
        /// </summary>
        BoundBox GetAdjustedBox(PdfBoundBox box);

        /// <summary>
        /// Return a byte representation
        /// of the page image.
        /// Byte array is formatted as
        /// B-G-R-A ordered list.
        /// </summary>
        byte[] GetImage(RenderFlags flags);

        /// <summary>
        /// Return a byte representation
        /// of the page image.
        /// Byte array is formatted as
        /// B-G-R-A ordered list.
        /// </summary>
        byte[] GetImage();

        /// <summary>
        /// Return a byte representation
        /// of the page image.
        /// Byte array is formatted as
        /// B-G-R-A ordered list. Then it
        /// applies a predefined byte transformation
        /// to modify the image.
        /// </summary>
        byte[] GetImage(IImageBytesConverter converter);

        /// <summary>
        /// Return a byte representation
        /// of the page image.
        /// Byte array is formatted as
        /// B-G-R-A ordered list. Then it
        /// applies a predefined byte transformation
        /// to modify the image.
        /// </summary>
        byte[] GetImage(IImageBytesConverter converter, RenderFlags flags);
    }
}
