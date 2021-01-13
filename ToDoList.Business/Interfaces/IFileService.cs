using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Business.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// returns the virtual path of the generated pdf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string ExportPdf<T>(List<T> list) where T : class, new();
        /// <summary>
        /// returns the byte array of the generated pdf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] ExportExcel<T>(List<T> list) where T : class, new();
    }
}
