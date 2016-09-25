﻿using PersonalWebsite.Common;
using PersonalWebsite.Common.Enums;
using PersonalWebsite.Data;
using PersonalWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalWebsite.Services.Models
{
    public class SettingModel : ISettingModel
    {
        private readonly DataContext db;
        private readonly ICacheService _cacheService;

        public SettingModel(DataContext db, ICacheService cacheService)
        {
            this.db = db;
            _cacheService = cacheService;
        }

        public void AddSetting(AddSettingViewModel model)
        {
            db.Settings.Add(new Setting
            {
                Name = model.Name,
                Type = model.Type,
                Value = model.Value
            });
            db.SaveChanges();
        }

        public void EditSetting(EditSettingViewModel model)
        {
            var setting = db.Settings.Where(x => x.SettingId == model.SettingId).FirstOrDefault();

            setting.Name = model.Name;
            setting.Type = model.Type;
            setting.Value = model.Value;

            db.SaveChanges();
        }

        public EditSettingViewModel GetSettingForEdit(int id)
        {
            var setting = db.Settings.Where(x => x.SettingId == id)
                .Select(x => new EditSettingViewModel
                {
                    SettingId = x.SettingId,
                    Name = x.Name,
                    Value = x.Value,
                    Type = x.Type
                }
                ).FirstOrDefault();

            return setting;
        }

        public SettingViewModel GetSetting(int id)
        {
            var setting = db.Settings.Where(x => x.SettingId == id)
                .Select(x => new SettingViewModel
                {
                    SettingId = x.SettingId,
                    Name = x.Name,
                    Value = x.Value,
                    Type = x.Type
                }
                ).FirstOrDefault();

            return setting;
        }

        public List<SettingViewModel> GetSettings()
        {
            var settings = db.Settings.Select(x => new SettingViewModel
            {
                SettingId = x.SettingId,
                Name = x.Name,
                Value = x.Value,
                Type = x.Type
            }).ToList();

            return settings;
        }

        public Dictionary<string, SettingViewModel> GetDictionary()
        {
            var key = "Settings";
            var cachedSettings = _cacheService.Get<Dictionary<string, SettingViewModel>>(key);
            if (cachedSettings == null)
            {
                var settings = db.Settings.Select(x => new SettingViewModel
                {
                    SettingId = x.SettingId,
                    Name = x.Name,
                    Value = x.Value,
                    Type = x.Type
                }).ToDictionary(x => x.Name, x => x);

                _cacheService.Store(key, settings);
                return settings;
            }
            return cachedSettings;
        }

        public int GetInt(string key)
        {
            var dictionary = this.GetDictionary();
            int result;

            if (!dictionary.ContainsKey(key))
            {
                throw new Exception(string.Format("Missing Setting Name: {0}",key));
            }

            if (dictionary[key].Type == SettingDataType.INT)
            {
                if (!int.TryParse(dictionary[key].Value, out result))
                {
                    throw new Exception("Value doesn't match type");
                }
            }
            else
            {
                throw new Exception("Wrong Type");
            }
            return result;
        }

        public bool GetLogic(string key)
        {
            var dictionary = this.GetDictionary();
            bool result;

            if (!dictionary.ContainsKey(key))
            {
                throw new Exception(string.Format("Missing Setting Name: {0}", key));
            }

            if (dictionary[key].Type == SettingDataType.LOGIC)
            {
                if (!bool.TryParse(dictionary[key].Value, out result))
                {
                    throw new Exception("Value doesn't match type");
                }
            }
            else
            {
                throw new Exception("Wrong Type");
            }
            return result;
        }

        public decimal GetDecimal(string key)
        {
            var dictionary = this.GetDictionary();
            decimal result;

            if (!dictionary.ContainsKey(key))
            {
                throw new Exception(string.Format("Missing Setting Name: {0}", key));
            }

            if (dictionary[key].Type == SettingDataType.DECIMAL)
            {
                if (!decimal.TryParse(dictionary[key].Value, out result))
                {
                    throw new Exception("Value doesn't match type");
                }
            }
            else
            {
                throw new Exception("Wrong Type");
            }
            return result;
        }

        public string GetString(string key)
        {
            var dictionary = this.GetDictionary();
            string result;

            if (!dictionary.ContainsKey(key))
            {
                throw new Exception(string.Format("Missing Setting Name: {0}", key));
            }

            if (dictionary[key].Type == SettingDataType.STRING)
            {
                result = dictionary[key].Value;
            }
            else
            {
                throw new Exception("Wrong Type");
            }
            return result;
        }

        public void DeleteSetting(int id)
        {
            var setting = db.Settings.Where(x => x.SettingId == id).FirstOrDefault();

            db.Settings.Remove(setting);
            db.SaveChanges();
        }
    }
}