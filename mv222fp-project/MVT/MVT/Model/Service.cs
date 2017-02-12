using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVT.Model.DAL;
using System.ComponentModel.DataAnnotations;
using MVT.App_Infrastructure;

namespace MVT.Model// Marco Villegas
{

    public class Service
    {
        // Privata fält
        private MemberDAL _memberDAL;

        private KontaktDAL _kontaktDAL;

        private BefattningDAL _befattningDAL;

        private ActivityDAL _activityDAL;

        private MemberActivityDAL _memberActivityDAL;

        private ExisterarDAL _existerarDAL;

        private ExisterarDAL ExisterarDAL// Egenskaper som skapar DAL-klasser om det inte redan finns någora.
        {
            get { return _existerarDAL ?? (_existerarDAL = new ExisterarDAL()); }
        }

        private MemberDAL MemberDAL// Egenskaper som skapar DAL-klasser om det inte redan finns någora.
        {
            get { return _memberDAL ?? (_memberDAL = new MemberDAL()); }
        }

        private ActivityDAL ActivityDAL
        {
            get { return _activityDAL ?? (_activityDAL = new ActivityDAL()); }
        }

        private MemberActivityDAL MemberActivityDAL
        {
            get { return _memberActivityDAL ?? (_memberActivityDAL = new MemberActivityDAL()); }
        }

        private KontaktDAL KontaktDAL
        {
            //Om contactdal är null gör det till höger om ??
            get { return _kontaktDAL ?? (_kontaktDAL = new KontaktDAL()); }
        }

        private BefattningDAL BefattningDAL
        {
            //Om contactdal är null gör det till höger om ??
            get { return _befattningDAL ?? (_befattningDAL = new BefattningDAL()); }
        }


        public void DeleteMember(int memberId)// Tar bort spesifik medlem ur databasen.
        {
            MemberDAL.DeleteMember(memberId);
        }

        public void SaveMember(Member member) // Sparar en medlem i databasen.
        {
            // Uppfyller inte objektet affärsreglerna
            ICollection<ValidationResult> validationResults;
            if (!member.Validate(out validationResults))
            {
                // Klarar inte objektet valideringen så kastas ett undantag, samt en referens till valideringssamlingen.
                var ex = new ValidationException("klarade inte valideringen");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }


            if (member.MedID == 0) // om MedID är 0 så skpas en ny medlem
            {
                MemberDAL.InsertMember(member);
            }
            else //Sparar medlem med andra ord uppdateras en befintlig medlems infromation
            {
                MemberDAL.UpdateMember(member);
            }
        }


        public Member GetMember(int memberId) // Hämtar en medlem med ett specifikt id från databasen
        {
            return MemberDAL.GetMemberById(memberId);
        }


        public IEnumerable<Member> GetMembers()    // Hämtar alla medlemmar ur databasen.
        {
            return MemberDAL.GetMembers();
        }


        //Hämtar alla kontakttyper returnernar ett List objekt innehållande referenser till ContactType objekt.
        public IEnumerable<KontaktTyp> GetKontaktTypes(bool refresh = false)
        {
            // Försöker hämta lista med kontakttyper från cachen.
            var kategoriTypes = HttpContext.Current.Cache["KategoriTypes"] as IEnumerable<KontaktTyp>;

            // Om det inte finns det en lista med kontakttyper
            if (kategoriTypes == null || refresh)
            {
                // ...hämtar då lista med kontakttyper
                kategoriTypes = KontaktDAL.GetKontakter();

                // ...och cachar dessa. List-objektet, inklusive alla ContactType-objekt, kommer att cachas 
                // under 5 minuter, varefter de automatiskt avallokeras från webbserverns primärminne.
                HttpContext.Current.Cache.Insert("KategoriTypes", kategoriTypes, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
            }

            // Returnerar listan med kontakttyper.
            return kategoriTypes;
        }

        //Kontakt 
     
        public IEnumerable<KontaktTyp> GetMemberKontaktTinfo(int memberId)
        {
            return KontaktDAL.GetMemberKontaktInfoById(memberId);
        }

        public void AddKontaktInfo(KontaktTyp K)
        {
            KontaktDAL.AddKontaktInfoById(K);
        }

        public void UpdateKontaktInfo(KontaktTyp K)
        {
            KontaktDAL.UpdateKontaktInfoById(K);
        }

        public void DeletKontaktInfo(KontaktTyp K)
        {
            KontaktDAL.DeletKontaktInfoById(K);
        }

   

        //Hämtar alla Befattningar returnernar ett List objekt innehållande referenser till BefattningTypes objekt.
        public IEnumerable<Befattning> GetBefattningTypes(bool refresh = false)
        {
            // Försöker hämta lista med BefattningTyper från cachen.
            var BefattningTypes = HttpContext.Current.Cache["BefattningTypes"] as IEnumerable<Befattning>;

            // Om det inte finns det en lista med BefattningTyper 
            if (BefattningTypes == null || refresh)
            {
                // ...hämtar då lista med BefattningTyper 
                BefattningTypes = BefattningDAL.GetallaBefattning();

                // ...och cachar dessa. List-objektet, inklusive alla BefattningTyper -objekt, kommer att cachas 
                // under 5 minuter, varefter de automatiskt avallokeras från webbserverns primärminne.
                HttpContext.Current.Cache.Insert("BefattningTypes", BefattningTypes, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
            }

            // Returnerar listan med kontakttyper.
            return BefattningTypes;
        }

        // Befattning

        public IEnumerable<Befattning> GetBefattninginfo(int MedID)
        {
            return BefattningDAL.GetBefattningByID(MedID);
        }

        public void UpdateBefattning(Befattning B)
        {
            BefattningDAL.UpdateBefattningByID(B);
        }

        public IEnumerable<Befattning> GetBefattningData(Befattning B)
        {
            return BefattningDAL.GetBefattningDataInfo(B);
        }


        public void DeleteBefattning(Befattning B)
        {
            BefattningDAL.DeleteBefattningId(B);
        }

        public void AddBefattningInfo(Befattning B)
        {
            BefattningDAL.AddBefattning(B);
        }

        //Aktivteter 
        public IEnumerable<Activity> GetActivities()
        {
            return ActivityDAL.GetActivities();
        }

        public void AddAktivitetInfo(Activity A)
        {
            ActivityDAL.AddAktivitet(A);
        }


        // Hämtar deltagar på specifik aktivitet
        public IEnumerable<ActivityType> GetActivityById(int id)
        {
            return MemberActivityDAL.GetActivityById(id);
        }

        // Tar bort en medlemsaktivitet
        public void DeleteMemberActivityById(ActivityType A)
        {
            MemberActivityDAL.DeleteMemberActivityById(A);
        }

        // Lägger till en medlemsaktivitet i databasen
        public void SaveMemberActivity(MemberActivity memberActivity)
        {
            // Uppfyller inte objektet affärsreglerna...
            ICollection<ValidationResult> validationResults;
            if (!memberActivity.Validate(out validationResults))
            {
                // Klarar inte objektet valideringen så kastas ett undantag, samt en referens till valideringssamlingen.
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            // Sparar contact-objektet. Är MedAktID 0 skapas en ny medlemsaktivitet...
            if (memberActivity.MedAktID == 0)
            {
                MemberActivityDAL.InsertMemberActivity(memberActivity);
            }
    
        }

        public void UpdateActivityInfo(Activity K)
        {
            ActivityDAL.UpdateAktivitetInfoById(K);
        }

        public void DeletActivitytInfo(Activity K)
        {
            ActivityDAL.DeletActivityt(K);
        }

        public IEnumerable<ActivityType> MedlemDeltarAktiviteterInfo(int id)
        {
            return MemberActivityDAL.MedlemDeltarAktiviteter(id);
        }

        public void ExisterarMedlemAktivitetInfo(MemberActivity M)
        {
            ExisterarDAL.ExisterarMedlemAktivitet(M);
        }


        //bild
        private ImageDAL _ImageDAL;

        private ImageDAL ImageDAL
        {
            get { return _ImageDAL ?? (_ImageDAL = new ImageDAL()); }
        }
        public void UpdateProduct(ImageTyp p)
        {

            ICollection<ValidationResult> validationResults;
            if (!p.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (p.MedlemID == 0) // New post if ID is 0!
            {
                ImageDAL.InsertProduct(p);
            }
            else
            {
                ImageDAL.UpdateProduct(p);
            }

        }


    }


}