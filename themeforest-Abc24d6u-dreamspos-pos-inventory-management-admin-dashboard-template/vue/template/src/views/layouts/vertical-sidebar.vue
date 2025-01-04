<template>
  <ul>
    <li class="submenu-open" v-for="item in side_bar_data" :key="item.tittle">
      <h6 class="submenu-hdr">{{ item.tittle }}</h6>
      <ul>
        <template v-for="menu in item.menu" :key="menu.menuValue">
          <li v-if="!menu.hasSubRoute" :class="{ active: isMenuActive(menu) }">
            <router-link v-if="menu.route" :to="menu.route">
              <vue-feather :type="menu.icon"></vue-feather>
              <span>{{ menu.menuValue }}</span></router-link>
          </li>
          <li v-else class="submenu">
            <a href="javascript:void(0)" @click="expandSubMenus(menu)" :class="{
              subdrop: menu.showSubRoute,
              active: route_array[1] === menu.active_link,
            }">
              <vue-feather :type="menu.icon"></vue-feather>
              <span>{{ menu.menuValue }}</span>
              <span class="menu-arrow"></span>
            </a>
            <ul :class="{
              'd-block': menu.showSubRoute,
              'd-none': !menu.showSubRoute,
            }">
              <li v-for="subMenu in menu.subMenus" :key="subMenu.menuValue">
                <router-link :to="subMenu.route" :class="{
                  active:
                    currentPath === subMenu.active_link ||
                    currentPath === subMenu.active_link1,
                }">
                  {{ subMenu.menuValue }}
                </router-link>
              </li>
            </ul>
          </li>

          <li v-if="menu.hasSubRouteTwo" class="submenu">
            <a href="javascript:void(0);" @click="openMenu(menu)" :class="{
              subdrop: menu.menuValue === 'Application' && isMenuActive(menu),
              active: isMenuActive(menu),
            }">
              <vue-feather :type="menu.icon"></vue-feather>
              <span>{{ menu.menuValue }}</span>
              <span class="menu-arrow"></span>
            </a>

            <ul :class="{
              'd-block': openMenuItem === menu,
              'd-none': openMenuItem !== menu,
            }">
              <template v-for="subMenus in menu.subMenus" :key="subMenus.menuValue">
                <li v-if="!subMenus.customSubmenuTwo">
                  <router-link :to="subMenus.route">{{
                    subMenus.menuValue
                  }}</router-link>
                </li>
                <template v-else-if="subMenus.customSubmenuTwo">
                  <li class="submenu submenu-two">
                    <a href="javascript:void(0);" @click="openSubmenuOne(subMenus)" :class="{
                      subdrop: openSubmenuOneItem === subMenus,
                      active: route_array[1] === subMenus.active_link,
                    }">
                      {{ subMenus.menuValue }}
                      <span class="menu-arrow"></span>
                    </a>
                    <ul :class="{
                      'd-block': openSubmenuOneItem === subMenus,
                      'd-none': openSubmenuOneItem !== subMenus,
                    }">
                      <li v-for="subMenuTwo in subMenus.subMenusTwo" :key="subMenuTwo.menuValue">
                        <router-link :to="subMenuTwo.route">{{
                          subMenuTwo.menuValue
                        }}</router-link>
                      </li>
                    </ul>
                  </li>
                </template>
              </template>
            </ul>
          </li>
        </template>
      </ul>
    </li>
  </ul>
</template>

<script>
import side_bar_data from "@/assets/json/sidebar.json";

export default {
  data() {
    return {
      side_bar_data: side_bar_data,
      openMenuItem: null,
      openSubmenuOneItem: null,
      route_array: [],
      multilevel: [false, false, false],
    };
  },
  methods: {
    expandSubMenus(menu) {
      this.side_bar_data.forEach((item) => {
        if (item.menu && Array.isArray(item.menu)) {
          item.menu.forEach((subMenu) => {
            if (subMenu !== menu) {
              subMenu.showSubRoute = false;
            }
          });
        }
      });
      menu.showSubRoute = !menu.showSubRoute;
    },
    openMenu(menu) {
      this.openMenuItem = this.openMenuItem === menu ? null : menu;
    },
    openSubmenuOne(subMenus) {
      this.openSubmenuOneItem =
        this.openSubmenuOneItem === subMenus ? null : subMenus;
    },
    getCurrentPath() {
      this.route_array = this.$route.path.split("/");
      return this.$route.path;
    }
  },
  computed: {
    currentPath() {
      return this.getCurrentPath();
    },
    isMenuActive() {
      return (menu) => {
        if (menu.menuValue === "Application") {
          return (
            this.$route.path.startsWith('/application') || // Check if current route starts with '/application'
            this.$route.path.startsWith('/call') ||
            this.$route.path === menu.active_link ||
            this.$route.path === menu.active_link1 ||
            this.$route.path === menu.active_link2
          );
        } else {
          return (
            this.$route.path === menu.route ||
            this.$route.path === menu.active_link ||
            this.$route.path === menu.active_link1 ||
            this.$route.path === menu.active_link2 ||
            this.$route.path === menu.active_link3 ||
            this.$route.path === menu.active_link4 ||
            this.$route.path === menu.active_link5
          );
        }
      };
    },
  },
};
</script>
