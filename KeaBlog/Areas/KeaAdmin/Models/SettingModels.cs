using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KeaBLL;
using KeaDAL;
using ServiceLib;

namespace KeaBlog.Areas.KeaAdmin.Models
{
    public class SettingViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Value of setting is required.")]
        public string Value { get; set; }
        
        public void DbUpdate()
        {
            Setting setting = new Setting();
            ModelMapping.ViewModelToModel(this, setting);
            SettingManager.WriteSetting(setting.Name, setting.Value);
        }
    }

    public class SettingListViewModel
    {
        public IList<SettingViewModel> Settings { get; set; }

        public void FillAll()
        {
            Settings = new List<SettingViewModel>();
            SettingViewModel viewModel;
            List<Setting> modelList = SettingManager.GetSettingList();
            foreach (var model in modelList)
            {
                viewModel = new SettingViewModel();
                ModelMapping.ModelToViewModel(model, viewModel);
                Settings.Add(viewModel);
            }
        }
    }
}