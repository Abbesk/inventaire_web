//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventaire_BackEnd.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class utilisateurpv
    {
        public string codeuser { get; set; }
        public string nom { get; set; }
        public string codepv { get; set; }
        public string libpv { get; set; }
        public string pvdefaut { get; set; }
        public string afftot { get; set; }
        public string codedep { get; set; }
        public string societe_code { get; set; }
        public string libdep { get; set; }
    
        public virtual pointvente pointVente { get; set; }
        public virtual societe societe { get; set; }
    }
}
