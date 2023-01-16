using System.ComponentModel;

namespace Geocoding_App
{
    static class Config
    {
        public const string url = "https://nominatim.openstreetmap.org/reverse";
        public const string user_agent = "GeoSpotter Photo - BIG";
        public const string format = "json";
        public const string zoom = "10";
        public static int startIndexRichText { get; set; }
        public static string pathFrom { get; set; }
        public static string pathTo { get; set; }
        public static int languageSelected { get; set; }
        public static bool country { get; set; }
        public static bool state { get; set; }
        public static bool county { get; set; }
        public static bool city { get; set; }
        public static string[] lista { get; set; }
        public static readonly string[] languages = { "English", "Español" };
        public static readonly string[,] languagesPhrases =
        {
            { "Source","Origen","Kilde" },
            { "Destination","Destino","Skæbne" },
            { "Country","País","Land" },
            { "State","Provincia","Stat" },
            { "City","Ciudad","By" },
            { "The Source directory and the Destination directory must not be empty and cannot be the same.",
              "El directorio de Origen y el directorio de Destino no pueden estar vacios y no pueden ser iguales.",
              "Kildebiblioteket og destinationsbiblioteket må ikke være tomme og kan ikke være det samme." },
            { "Warning Message","Mensaje de Advertencia","Advarselsmeddelelse" },
            { "Select the folder that contains the photos",
              "Seleccione el directorio que contenga las fotos",
              "Vælg den mappe, der indeholder billederne" },
            { "Select the folder where the photos will be store",
              "Seleccione el directorio donde se guardaran las fotos",
              "Vælg den mappe, hvor billederne skal gemmes" },
            { "Start", "Iniciar", "Start" },
            { "This amount of images will be sorted by folders: ", //10
              "Esta cantidad de imágenes se ordenaran por carpetas: ",
              "Denne mængde billeder vil blive sorteret efter mapper: " },
            { "Are you sure to proceed?", "¿Esta seguro de proceder?", "Er du sikker på at du vil fortsætte?" },
            { "You must select a Source folder that contains images.", 
              "Debe seleccionar una carpeta de Origen que contenga imágenes.",
              "Du skal vælge en kildemappe, der indeholder billeder." },
            { "You must select at least one sort option.", 
              "Debe seleccionar al menos una opción de ordenación.",
              "Du skal vælge mindst én sorteringsmulighed." },
            { "Failed: ", "Fallido: ", "Mislykkedes: " },
            { "Success: ", "Éxito: ", "Succes: " },
            { "Images that has not been possible to obtain their GPS information: ", 
              "Imágenes que no ha sido posible obtener su información GPS: ",
              "Billeder, der ikke har været muligt at få deres GPS-oplysninger: " },
            { "Images sorted successfully: ", "Imágenes ordenadas con éxito: ", "Billeder sorteret med succes: " },
            { "The process has been completed.\nYou can close the program.", 
              "Se ha completado el proceso.\nPuede cerrar el programa.",
              "Processen er afsluttet.\nDu kan lukke programmet." },
            { "Finalized", "Finalizado", "Afsluttet" },
            { "The selected Source folder no longer exists.", //20
              "La carpeta de Origen seleccionada ya no existe.", 
              "Den valgte kildemappe eksisterer ikke længere." },
            { "The selected Destination folder no longer exists.",
              "La carpeta de Destino seleccionada ya no existe.", 
              "Den valgte destinationsmappe eksisterer ikke længere." },
            { "County","Condado","Amt" },
            { "Cancel", "Cancelar", "Afbestille" },
            { "Canceled", "Cancelado", "Annulleret" },
            { "Canceled!", "¡Cancelado!", "Annulleret!" },
            { "Error", "Error", "Fejl" }
        };
    }
}
