/*
 Navicat Premium Data Transfer

 Source Server         : local
 Source Server Type    : MySQL
 Source Server Version : 50739
 Source Host           : localhost:3306
 Source Schema         : ZTAdmin

 Target Server Type    : MySQL
 Target Server Version : 50739
 File Encoding         : 65001

 Date: 30/09/2022 23:45:41
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for cars_game
-- ----------------------------
DROP TABLE IF EXISTS `cars_game`;
CREATE TABLE `cars_game`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '游戏名称',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '状态',
  `Summary` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '规则',
  `ConfigRule` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '配置相关获得积分策略',
  `AddTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '添加时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '游戏设置表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cars_game
-- ----------------------------

-- ----------------------------
-- Table structure for cars_prize
-- ----------------------------
DROP TABLE IF EXISTS `cars_prize`;
CREATE TABLE `cars_prize`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `Name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '活动名称',
  `StartTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '开始时间',
  `EndTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '结束时间',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '活动状态',
  `PickCount` int(11) NOT NULL DEFAULT 0 COMMENT '中奖次数',
  `Prizes` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '奖品',
  `DrawNumber` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '设置的抽奖次数',
  `Summary` longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '活动规则',
  `CreateTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '添加时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '奖品表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cars_prize
-- ----------------------------

-- ----------------------------
-- Table structure for cars_prizelog
-- ----------------------------
DROP TABLE IF EXISTS `cars_prizelog`;
CREATE TABLE `cars_prizelog`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `UserId` bigint(20) NOT NULL DEFAULT 0 COMMENT '用户编号',
  `PrizeId` bigint(20) NOT NULL DEFAULT 0 COMMENT '奖品ID',
  `PrizeInfo` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '中奖信息',
  `Status` bit(1) NOT NULL DEFAULT b'0' COMMENT '发放状态',
  `CreateTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '中奖时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '抽奖记录' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cars_prizelog
-- ----------------------------

-- ----------------------------
-- Table structure for cars_reserve
-- ----------------------------
DROP TABLE IF EXISTS `cars_reserve`;
CREATE TABLE `cars_reserve`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `UserId` bigint(20) NOT NULL DEFAULT 0 COMMENT '用户编号',
  `Name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '姓名',
  `Sex` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '性别',
  `Mobile` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '电话',
  `City` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '城市',
  `County` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '区县',
  `CarType` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '车型',
  `ReserveTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '预约时间',
  `Status` bit(1) NOT NULL DEFAULT b'0' COMMENT '处理状态',
  `CreateTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '添加时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '预约试驾' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cars_reserve
-- ----------------------------
INSERT INTO `cars_reserve` VALUES (1511967662069125120, 1511955043186774017, '李先生', '男', '13654545214', '北京市-市辖区-东城区', NULL, '北京X7 PHEV', '2022-04-29 00:00:00', b'0', '2022-04-07 15:22:36');

-- ----------------------------
-- Table structure for cms_adv_column
-- ----------------------------
DROP TABLE IF EXISTS `cms_adv_column`;
CREATE TABLE `cms_adv_column`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `ParentId` bigint(20) NOT NULL DEFAULT 0 COMMENT '父编号',
  `ParentIdList` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '父编号集合',
  `Layer` int(11) NOT NULL DEFAULT 1 COMMENT '层级',
  `Name` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '栏目名称',
  `Flag` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '栏目类型',
  `Width` int(11) NOT NULL DEFAULT 0 COMMENT '栏目宽度',
  `Height` int(11) NOT NULL DEFAULT 0 COMMENT '栏目高度',
  `Sort` int(11) NULL DEFAULT NULL COMMENT '排序',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '栏目状态',
  `Summary` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '栏目说明',
  `SiteId` bigint(20) NOT NULL DEFAULT 0 COMMENT '站点ID',
  `CreateTime` datetime NULL DEFAULT NULL COMMENT '添加时间',
  `CreateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '添加人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '广告位栏目表 ' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of cms_adv_column
-- ----------------------------
INSERT INTO `cms_adv_column` VALUES (1366296925808234496, 0, '1366296925808234496,', 1, '小程序', 'C', 0, 0, 0, b'1', NULL, 0, '2021-03-01 15:59:06', NULL, '0001-01-01 00:00:00', NULL);
INSERT INTO `cms_adv_column` VALUES (1366318607604256768, 1366296925808234496, '1366296925808234496,1366318607604256768,', 2, '轮播图', 'A', 790, 300, 0, b'1', NULL, 0, '2021-03-01 17:25:16', NULL, '0001-01-01 00:00:00', NULL);
INSERT INTO `cms_adv_column` VALUES (1382891060254085120, 0, '1382891060254085120,', 1, '友情链接', 'F', 0, 0, NULL, b'1', NULL, 0, '2021-04-16 10:58:16', '张三', NULL, NULL);

-- ----------------------------
-- Table structure for sys_admin
-- ----------------------------
DROP TABLE IF EXISTS `sys_admin`;
CREATE TABLE `sys_admin`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `RoleGroup` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '所属角色',
  `RoleGroupParent` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '所属角色，包含父级',
  `PostGroup` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '所属岗位',
  `OrganizeId` bigint(20) NOT NULL COMMENT '所属部门',
  `OrganizeIdList` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '所属上级部门组',
  `LoginAccount` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '登录账号',
  `LoginPassWord` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '登录密码',
  `HeadPic` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '头像',
  `FullName` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '姓名',
  `Mobile` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '手机号码',
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '邮箱',
  `Sex` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '性别',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '状态',
  `IsDel` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `Summary` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `CreateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  `LoginTime` datetime NULL DEFAULT NULL COMMENT '登录时间',
  `UpLoginTime` datetime NULL DEFAULT NULL COMMENT '上次登录时间',
  `LoginCount` int(11) NOT NULL DEFAULT 0 COMMENT '登录次数',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '管理员表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_admin
-- ----------------------------
INSERT INTO `sys_admin` VALUES (1260380358965334016, '[\"1339756014718816256\"]', '[[\"1339755942329323520\",\"1339756014718816256\"]]', '[\"1251019168074043392\"]', 1247889786656657408, '[\"1247889786656657408\"]', 'admin', 'paBHiChduM9YK+IgadY/4w==', '/upload/avatar/6.jpg', '李四', '13511111111', '222@qq.com', '男', b'1', b'0', '正所谓富贵险中求', '2020-05-13 09:24:29', 'admin', '2022-09-28 01:24:05', 'Admin', '2022-09-28 01:24:05', '2022-09-28 01:24:05', 458);
INSERT INTO `sys_admin` VALUES (1519584258979663873, '[\"1474270785488162818\"]', '[[\"1339755942329323520\",\"1474270785488162818\"]]', '[\"1251019232876040192\"]', 1248157435479330816, '[\"1247889786656657408\",\"1248157435479330816\"]', 'testadmin', 'i2Dvw+YPAnADdVkAX5B/rg==', '', 'testrole', '13777373733', '', '男', b'1', b'0', '', '2022-04-28 15:48:14', 'Admin', '2022-05-21 09:56:55', 'Admin', '2022-05-21 09:56:55', '2022-05-21 09:56:55', 9);

-- ----------------------------
-- Table structure for sys_adv_column
-- ----------------------------
DROP TABLE IF EXISTS `sys_adv_column`;
CREATE TABLE `sys_adv_column`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `ParentId` bigint(20) NOT NULL DEFAULT 0 COMMENT '父编号',
  `ParentIdList` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '父编号集合',
  `Layer` int(11) NOT NULL DEFAULT 1 COMMENT '层级',
  `Name` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '栏目名称',
  `Flag` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '栏目类型',
  `Width` int(11) NOT NULL DEFAULT 0 COMMENT '栏目宽度',
  `Height` int(11) NOT NULL DEFAULT 0 COMMENT '栏目高度',
  `Sort` int(11) NULL DEFAULT NULL COMMENT '排序',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '栏目状态',
  `Summary` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '栏目说明',
  `SiteId` bigint(20) NOT NULL DEFAULT 0 COMMENT '站点ID',
  `CreateTime` datetime NULL DEFAULT NULL COMMENT '添加时间',
  `CreateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '添加人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '广告位栏目表 ' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_adv_column
-- ----------------------------
INSERT INTO `sys_adv_column` VALUES (1366296925808234496, 0, '[\"1366296925808234496\"]', 1, '小程序', 'C', 0, 0, 0, b'1', NULL, 0, '2021-03-01 15:59:06', NULL, '0001-01-01 00:00:00', NULL);
INSERT INTO `sys_adv_column` VALUES (1509706399330996224, 1366296925808234496, '[\"1366296925808234496\",\"1509706399330996224\"]', 2, '预约试驾', 'reserve', 600, 400, 2, b'1', NULL, 0, '2022-04-01 09:37:09', NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sys_adv_info
-- ----------------------------
DROP TABLE IF EXISTS `sys_adv_info`;
CREATE TABLE `sys_adv_info`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `ColumnId` bigint(20) NOT NULL DEFAULT 0 COMMENT '栏目Id',
  `Title` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '广告名称',
  `Types` int(11) NOT NULL DEFAULT 1 COMMENT '广告位类型',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '状态',
  `ImgUrl` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '广告位图片',
  `LinkUrl` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '连接地址',
  `Target` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '跳转方式',
  `Summary` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '描述',
  `Codes` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '广告位代码',
  `IsTimeLimit` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否开启时间限制',
  `BeginTime` datetime NULL DEFAULT NULL COMMENT '开始时间',
  `EndTime` datetime NULL DEFAULT NULL COMMENT '结束时间',
  `Sort` int(11) NOT NULL DEFAULT 1 COMMENT '排序',
  `Hits` int(11) NOT NULL DEFAULT 0 COMMENT '广告点击率',
  `CreateTime` datetime NULL DEFAULT NULL COMMENT '添加时间',
  `CreateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '添加人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '广告位信息表 ' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_adv_info
-- ----------------------------
INSERT INTO `sys_adv_info` VALUES (1509707020842962944, 1509706399330996224, '预约试驾', 1, b'1', '/upload/adv/xxdj.jpg', '1', '_blank', NULL, NULL, b'0', NULL, NULL, 1, 0, '2022-04-01 09:39:37', NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sys_authority
-- ----------------------------
DROP TABLE IF EXISTS `sys_authority`;
CREATE TABLE `sys_authority`  (
  `RoleId` bigint(20) NOT NULL COMMENT '角色编号',
  `AdminId` bigint(20) NULL DEFAULT NULL COMMENT '管理员编号',
  `MenuId` bigint(20) NULL DEFAULT NULL COMMENT '菜单编号',
  `Api` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '按钮功能组',
  `Types` int(11) NOT NULL DEFAULT 1 COMMENT '授权类型1=角色-菜单 2=用户-角色 3=角色-菜单-按钮功能'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '授权表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_authority
-- ----------------------------
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505743735667953665, '[]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505749765281943553, '[]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505750741799800833, '[{\"code\":\"查看\",\"method\":\"POST\",\"url\":\"/api/generator\"},{\"code\":\"生成\",\"method\":\"POST\",\"url\":\"/api/generator\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505751087574028289, '[{\"code\":\"上传\",\"method\":\"POST\",\"url\":\"/api/sysfile/upload\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/sysfile/file\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505752932937764865, '[]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505753200123318273, '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/sysorganize\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/sysorganize\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/sysorganize\"},{\"code\":\"排序\",\"method\":\"POST\",\"url\":\"/api/sysorganize/colsort\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505753465199136769, '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/sysrole\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/sysrole\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/sysrole\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505753657151459329, '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/syspost\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/syspost\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/syspost\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505753850097831937, '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/sysadmin\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/sysadmin\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/sysadmin\"},{\"code\":\"密码重置\",\"method\":\"PUT\",\"url\":\"/api/sysadmin/passreset\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505753983766106113, '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/sysmenu/temp\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/sysmenu\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/sysmenu\"},{\"code\":\"排序\",\"method\":\"POST\",\"url\":\"/api/sysmenu/colsort\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505754140607909889, '[{\"code\":\"保存\",\"method\":\"POST\",\"url\":\"/api/sysauthority\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505754323739611137, '[{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/syslog\"},{\"code\":\"清空\",\"method\":\"DELETE\",\"url\":\"/api/syslog/clear\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1519508966684626944, '[]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505750037081231361, '[{\"code\":\"查看\",\"method\":\"GET\",\"url\":\"/api/sysadmin/basic\"}]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505750499046068225, '[]', 3);
INSERT INTO `sys_authority` VALUES (1474270785488162818, 0, 1505751488931172353, '[{\"code\":\"已读\",\"method\":\"PUT\",\"url\":\"/api/sysmessage/read\"},{\"code\":\"回收站\",\"method\":\"DELETE\",\"url\":\"/api/sysmessage/recycle\"}]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505743735667953665, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505749765281943553, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505750037081231361, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505750499046068225, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505750741799800833, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505751087574028289, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505751488931172353, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505751622146461697, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505764157008515073, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1519880746058256384, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1530078871695790080, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505751857547579393, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505752082601349121, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505752395358015489, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505752728201203713, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505752932937764865, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505753200123318273, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505753465199136769, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505753657151459329, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505753850097831937, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505753983766106113, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505754140607909889, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1505754323739611137, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1519508966684626944, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506093853084618753, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506094265032380417, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506094494225928193, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506094671250722817, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1527239267519172608, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506187567358414849, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506188179915542529, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506188430009307137, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506524557157208065, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506524879816626177, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506559646230515713, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506560054290157569, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506560247593046017, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506812417865289729, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506812669225734145, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1506812834963656705, '[]', 3);
INSERT INTO `sys_authority` VALUES (1339756014718816256, 0, 1514445260992942081, '[]', 3);

-- ----------------------------
-- Table structure for sys_city
-- ----------------------------
DROP TABLE IF EXISTS `sys_city`;
CREATE TABLE `sys_city`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一标识',
  `Name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '城市名称',
  `ParentId` bigint(20) NOT NULL DEFAULT 1 COMMENT '所属上级',
  `ParentIdList` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '所属上级组',
  `Layer` int(11) NOT NULL DEFAULT 1 COMMENT '层级',
  `Code` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '城市编号',
  `Longitude` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '经度',
  `Dimension` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '维度',
  `Sort` int(11) NULL DEFAULT 1 COMMENT '排序',
  `AddTime` datetime NOT NULL COMMENT '添加时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '城市表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_city
-- ----------------------------
INSERT INTO `sys_city` VALUES (1505158225400565760, '北京', 0, '[\"1505158225400565760\"]', 1, '100000', NULL, NULL, 2, '2022-03-19 20:24:20');
INSERT INTO `sys_city` VALUES (1505160686236471296, '上海', 0, '[\"1505160686236471296\"]', 1, '322000', NULL, NULL, 3, '2022-03-19 20:34:07');

-- ----------------------------
-- Table structure for sys_code
-- ----------------------------
DROP TABLE IF EXISTS `sys_code`;
CREATE TABLE `sys_code`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `TypeId` bigint(20) NOT NULL COMMENT '分类编号',
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '字典值名称',
  `CodeValues` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '字典值阈值',
  `Sort` int(11) NOT NULL DEFAULT 1 COMMENT '排序',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '状态',
  `IsDel` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `Summary` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注',
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `CreateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '字典信息表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_code
-- ----------------------------
INSERT INTO `sys_code` VALUES (1506528204201005056, 1506527460819341312, '北京X7 PHEV', 'BEIJING-X7 PHEV', 1, b'1', b'0', NULL, '2022-03-23 15:08:08', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528251835715584, 1506527460819341312, '北京X3', 'X3', 1, b'1', b'0', NULL, '2022-03-23 15:08:20', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528300959404032, 1506527460819341312, '北京X5', 'X5', 1, b'1', b'0', NULL, '2022-03-23 15:08:32', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528348422148096, 1506527460819341312, '北京U5 PLUS', 'BEIJING-U5 PLUS', 1, b'1', b'0', NULL, '2022-03-23 15:08:43', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528394265890816, 1506527460819341312, '北京U5', 'U5', 1, b'1', b'0', NULL, '2022-03-23 15:08:54', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528436917768192, 1506527460819341312, '北京U7', 'U7', 1, b'1', b'0', NULL, '2022-03-23 15:09:04', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528469780140032, 1506527460819341312, '北京X7', 'X7', 1, b'1', b'0', NULL, '2022-03-23 15:09:12', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528512943722496, 1506527460819341312, '北京汽车魔方', '北京汽车魔方', 1, b'1', b'0', NULL, '2022-03-23 15:09:22', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528544732352512, 1506527460819341312, '北京EX3', 'EX3', 1, b'1', b'0', NULL, '2022-03-23 15:09:30', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528575707287552, 1506527460819341312, '北京EX5', 'EX5', 1, b'1', b'0', NULL, '2022-03-23 15:09:37', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528644045082624, 1506527460819341312, '北京EU5 PLUS', 'BEIJING-EU5 PLUS', 1, b'1', b'0', NULL, '2022-03-23 15:09:53', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528678677450752, 1506527460819341312, '北京EU5', 'EU5', 1, b'1', b'0', NULL, '2022-03-23 15:10:02', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506528715759292416, 1506527460819341312, '北京EU7', 'EU7', 1, b'1', b'0', NULL, '2022-03-23 15:10:10', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506529177661214720, 1506527796082642944, '北京北汽智慧能源科技有限公司', 'A', 1, b'1', b'0', NULL, '2022-03-23 15:12:01', NULL, NULL, NULL);
INSERT INTO `sys_code` VALUES (1506529251283832832, 1506527796082642944, '北京祥盛通达汽车服务有限公司', 'B', 1, b'1', b'0', NULL, '2022-03-23 15:12:18', NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sys_codetype
-- ----------------------------
DROP TABLE IF EXISTS `sys_codetype`;
CREATE TABLE `sys_codetype`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `ParentId` bigint(20) NOT NULL COMMENT '父节点',
  `ParentIdList` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Layer` int(11) NOT NULL DEFAULT 1 COMMENT '层级',
  `Name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '分类名称',
  `Code` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '标识',
  `Types` int(11) NOT NULL DEFAULT 1 COMMENT '1=系统 2=商城',
  `Sort` int(11) NOT NULL DEFAULT 1 COMMENT '排序',
  `IsSystem` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否系统内置集成',
  `IsDel` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `CreateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '字典分类信息' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_codetype
-- ----------------------------
INSERT INTO `sys_codetype` VALUES (1506527288022405120, 0, '[\"1506527288022405120\"]', 1, '预约信息', 'reserve', 1, 11, b'0', b'0', '2022-03-23 15:04:30', NULL, NULL, NULL);
INSERT INTO `sys_codetype` VALUES (1506527460819341312, 1506527288022405120, '[\"1506527288022405120\",\"1506527460819341312\"]', 2, '车型', 'car-type', 1, 12, b'0', b'0', '2022-03-23 15:05:11', NULL, NULL, NULL);
INSERT INTO `sys_codetype` VALUES (1506527796082642944, 1506527288022405120, '[\"1506527288022405120\",\"1506527796082642944\"]', 2, '经销商', 'dealers', 1, 13, b'0', b'0', '2022-03-23 15:06:31', NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sys_file_column
-- ----------------------------
DROP TABLE IF EXISTS `sys_file_column`;
CREATE TABLE `sys_file_column`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `ParentId` bigint(20) NOT NULL DEFAULT 0 COMMENT '父编号',
  `ParentIdList` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '父编号集合',
  `Type` int(11) NOT NULL DEFAULT 0 COMMENT '类型 图片类型分类 0=本地 1=云端',
  `Layer` int(11) NOT NULL DEFAULT 1 COMMENT '级别',
  `Sort` int(11) NULL DEFAULT NULL COMMENT '排序',
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '栏目名称',
  `EnName` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '英文名称 文件夹名称',
  `CreateTime` datetime NULL DEFAULT NULL COMMENT '添加时间',
  `CreateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '添加人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '资源栏目表 ' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_file_column
-- ----------------------------

-- ----------------------------
-- Table structure for sys_file_info
-- ----------------------------
DROP TABLE IF EXISTS `sys_file_info`;
CREATE TABLE `sys_file_info`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `ColumnId` bigint(20) NOT NULL DEFAULT 0 COMMENT '所属栏目',
  `Name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '文件名称',
  `FileUrl` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '文件地址',
  `FileType` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '文件类型',
  `FileSize` bigint(20) NOT NULL COMMENT '文件大小',
  `ImgSmall` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '图片缩略图',
  `Sort` int(11) NOT NULL DEFAULT 1 COMMENT '排序',
  `IsDel` bit(1) NULL DEFAULT NULL COMMENT '是否删除',
  `CreateTime` datetime NULL DEFAULT NULL COMMENT '添加时间',
  `CreateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '添加人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '资源文件信息表 ' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_file_info
-- ----------------------------

-- ----------------------------
-- Table structure for sys_log
-- ----------------------------
DROP TABLE IF EXISTS `sys_log`;
CREATE TABLE `sys_log`  (
  `Id` bigint(20) NOT NULL,
  `Level` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '级别',
  `LogType` int(11) NOT NULL COMMENT '日志类型  1=登录  2=操作',
  `Module` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作模块',
  `OperateType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作类型:例如添加、修改',
  `Method` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '提交类型：get/post/delete',
  `OperateUser` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作人',
  `IP` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'IP',
  `Parameters` longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '请求参数',
  `Address` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作地址',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '操作状态',
  `Message` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '详细信息',
  `ReturnValue` longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL COMMENT '返回结果',
  `OperateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '操作时间',
  `Browser` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '浏览器信息',
  `ExecutionDuration` int(11) NOT NULL DEFAULT 0 COMMENT '执行时长',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '登录日志\r\n操作日志\r\n任务日志' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_log
-- ----------------------------

-- ----------------------------
-- Table structure for sys_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `Name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '菜单名称',
  `ParentId` bigint(20) NULL DEFAULT NULL COMMENT '父节点',
  `ParentIdList` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '父节点集合组',
  `Code` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '权限标识',
  `Layer` int(11) NOT NULL DEFAULT 1 COMMENT '菜单层级',
  `Urls` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '路由地址',
  `Redirect` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '重定向',
  `VuePath` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'Vue文件路径',
  `Icon` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单图标',
  `Active` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '菜单高亮',
  `Color` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '颜色',
  `Sort` int(11) NOT NULL DEFAULT 1 COMMENT '排序',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '状态',
  `IsDel` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `Types` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '1' COMMENT '菜单类型',
  `Api` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '接口权限',
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `CreateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '资源菜单表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES (1505743735667953665, '主页', 0, '[\"1505743735667953665\"]', 'home', 1, '/home', NULL, NULL, 'el-icon-house', NULL, NULL, 2, b'1', b'0', 'menu', '[]', '2022-03-21 11:10:57', NULL, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1505749765281943553, '工作台', 1505743735667953665, '[\"1505743735667953665\",\"1505749765281943553\"]', 'dashboard', 1, '/dashboard', NULL, 'home', 'el-icon-menu', NULL, NULL, 3, b'1', b'0', 'menu', '[]', '2022-03-21 11:34:54', NULL, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1505750037081231361, '个人信息', 1505743735667953665, '[\"1505743735667953665\",\"1505750037081231361\"]', 'userCenter', 1, '/usercenter', NULL, 'userCenter', 'el-icon-user', NULL, NULL, 4, b'1', b'0', 'menu', '[{\"code\":\"查看\",\"method\":\"GET\",\"url\":\"/api/sysadmin/basic\"},{\"code\":\"编辑\",\"method\":\"POST\",\"url\":\"/api/sysadmin/basic\"}]', '2022-03-21 11:35:59', NULL, '2022-05-20 18:46:08', 'Admin');
INSERT INTO `sys_menu` VALUES (1505751857547579393, '配置', 0, '[\"1505751857547579393\"]', 'setting', 1, '/setting', NULL, NULL, 'el-icon-setting', NULL, NULL, 10, b'1', b'0', 'menu', '[]', '2022-03-21 11:43:13', NULL, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1505752082601349121, '数据字典', 1505751857547579393, '[\"1505751857547579393\",\"1505752082601349121\"]', 'syscode', 1, '/sys/code', NULL, 'sys/code', 'el-icon-document-copy', NULL, NULL, 11, b'1', b'0', 'menu', '[{\"code\":\"添加栏目\",\"method\":\"POST\",\"url\":\"/api/syscodetype\"},{\"code\":\"编辑栏目\",\"method\":\"PUT\",\"url\":\"/api/syscodetype\"},{\"code\":\"删除栏目\",\"method\":\"DELETE\",\"url\":\"/api/syscodetype\"},{\"code\":\"添加字典\",\"method\":\"POST\",\"url\":\"/api/syscode\"},{\"code\":\"编辑字典\",\"method\":\"PUT\",\"url\":\"/api/syscode\"},{\"code\":\"删除字典\",\"method\":\"DELETE\",\"url\":\"/api/syscode\"}]', '2022-03-21 11:44:07', NULL, '2022-05-20 17:38:42', 'Admin');
INSERT INTO `sys_menu` VALUES (1505752395358015489, '城市区域', 1505751857547579393, '[\"1505751857547579393\",\"1505752395358015489\"]', 'syscity', 1, '/sys/city', NULL, 'sys/city', 'el-icon-aim', NULL, NULL, 12, b'1', b'0', 'menu', '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/syscity\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/syscity\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/syscity\"},{\"code\":\"排序\",\"method\":\"POST\",\"url\":\"/api/syscity/colsort\"}]', '2022-03-21 11:45:21', NULL, '2022-05-20 17:40:03', 'Admin');
INSERT INTO `sys_menu` VALUES (1505752728201203713, '安全设置', 1505751857547579393, '[\"1505751857547579393\",\"1505752728201203713\"]', 'syssafety', 1, '/sys/safety', NULL, 'sys/safety', 'el-icon-key', NULL, NULL, 13, b'1', b'0', 'menu', '[{\"code\":\"保存\",\"method\":\"POST\",\"url\":\"/api/syssafety\"}]', '2022-03-21 11:46:41', NULL, '2022-05-20 17:44:21', 'Admin');
INSERT INTO `sys_menu` VALUES (1505752932937764865, '系统', 0, '[\"1505752932937764865\"]', 'sys', 1, '/sys', NULL, NULL, 'el-icon-sunset', NULL, NULL, 14, b'1', b'0', 'menu', '[]', '2022-03-21 11:47:29', NULL, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1505753200123318273, '机构管理', 1505752932937764865, '[\"1505752932937764865\",\"1505753200123318273\"]', 'sysorganize', 1, '/sys/organize', NULL, 'sys/organize', 'el-icon-place', NULL, NULL, 15, b'1', b'0', 'menu', '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/sysorganize\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/sysorganize\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/sysorganize\"},{\"code\":\"排序\",\"method\":\"POST\",\"url\":\"/api/sysorganize/colsort\"}]', '2022-03-21 11:48:33', NULL, '2022-05-20 17:45:30', 'Admin');
INSERT INTO `sys_menu` VALUES (1505753465199136769, '角色管理', 1505752932937764865, '[\"1505752932937764865\",\"1505753465199136769\"]', 'sysrole', 1, '/sys/role', NULL, 'sys/role', 'el-icon-notebook', NULL, NULL, 16, b'1', b'0', 'menu', '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/sysrole\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/sysrole\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/sysrole\"}]', '2022-03-21 11:49:36', NULL, '2022-05-20 17:46:17', 'Admin');
INSERT INTO `sys_menu` VALUES (1505753657151459329, '职位管理', 1505752932937764865, '[\"1505752932937764865\",\"1505753657151459329\"]', 'syspost', 1, '/sys/post', NULL, 'sys/post', 'el-icon-monitor', NULL, NULL, 17, b'1', b'0', 'menu', '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/syspost\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/syspost\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/syspost\"}]', '2022-03-21 11:50:22', NULL, '2022-05-20 17:46:53', 'Admin');
INSERT INTO `sys_menu` VALUES (1505753850097831937, '用户管理', 1505752932937764865, '[\"1505752932937764865\",\"1505753850097831937\"]', 'sysadmin', 1, '/sys/admin', NULL, 'sys/admin', 'el-icon-user', NULL, NULL, 18, b'1', b'0', 'menu', '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/sysadmin\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/sysadmin\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/sysadmin\"},{\"code\":\"密码重置\",\"method\":\"PUT\",\"url\":\"/api/sysadmin/passreset\"}]', '2022-03-21 11:51:08', NULL, '2022-05-20 17:48:12', 'Admin');
INSERT INTO `sys_menu` VALUES (1505753983766106113, '资源管理', 1505752932937764865, '[\"1505752932937764865\",\"1505753983766106113\"]', 'sysmenu', 1, '/sys/menu', NULL, 'sys/menu', 'el-icon-expand', NULL, NULL, 19, b'1', b'0', 'menu', '[{\"code\":\"添加\",\"method\":\"POST\",\"url\":\"/api/sysmenu/temp\"},{\"code\":\"编辑\",\"method\":\"PUT\",\"url\":\"/api/sysmenu\"},{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/sysmenu\"},{\"code\":\"排序\",\"method\":\"POST\",\"url\":\"/api/sysmenu/colsort\"}]', '2022-03-21 11:51:40', NULL, '2022-05-20 17:49:46', 'Admin');
INSERT INTO `sys_menu` VALUES (1505754140607909889, '权限设置', 1505752932937764865, '[\"1505752932937764865\",\"1505754140607909889\"]', 'sysauthorize', 1, '/sys/authorize', NULL, 'sys/authorize', 'el-icon-finished', NULL, NULL, 20, b'1', b'0', 'menu', '[{\"code\":\"保存\",\"method\":\"POST\",\"url\":\"/api/sysauthority\"}]', '2022-03-21 11:52:17', NULL, '2022-05-20 17:53:48', 'Admin');
INSERT INTO `sys_menu` VALUES (1505754323739611137, '系统日志', 1505752932937764865, '[\"1505752932937764865\",\"1505754323739611137\"]', 'syslog', 1, '/sys/log', NULL, 'sys/log', 'el-icon-document-copy', NULL, NULL, 21, b'1', b'0', 'menu', '[{\"code\":\"删除\",\"method\":\"DELETE\",\"url\":\"/api/syslog\"},{\"code\":\"清空\",\"method\":\"DELETE\",\"url\":\"/api/syslog/clear\"}]', '2022-03-21 11:53:01', NULL, '2022-05-20 17:54:27', 'Admin');
INSERT INTO `sys_menu` VALUES (1519508966684626944, '在线用户', 1505752932937764865, '[\"1505752932937764865\",\"1519508966684626944\"]', 'sysonline', 1, '/sys/online', NULL, 'sys/online', 'el-icon-discount', NULL, NULL, 42, b'1', b'0', 'menu', '[]', '2022-04-28 10:49:03', 'Admin', '2022-04-28 10:51:22', 'Admin');

-- ----------------------------
-- Table structure for sys_message
-- ----------------------------
DROP TABLE IF EXISTS `sys_message`;
CREATE TABLE `sys_message`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `ColumnId` bigint(20) NOT NULL DEFAULT 0 COMMENT '栏目Id',
  `Types` int(11) NOT NULL DEFAULT 1 COMMENT '类型',
  `Title` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '留言标题',
  `Email` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '邮箱信息',
  `Mobile` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '手机号码',
  `Tags` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '留言标签',
  `Summary` varchar(1024) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '留言内容',
  `IsRead` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否已读',
  `IsDelete` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `UserId` bigint(20) NOT NULL DEFAULT 0 COMMENT '用户编号',
  `UserName` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '用户姓名',
  `CreateTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '添加时间',
  `CreateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '添加人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '留言消息表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_message
-- ----------------------------
INSERT INTO `sys_message` VALUES (1388447984265596928, 0, 1, '这里面是标题', '7155@qq.com', '135110110110', '测试、游戏、工作、需求', '具体的留言信息，请查看', b'1', b'0', 0, '张三', '2022-05-17 17:12:21', 'string', '2021-05-01 10:58:34', 'string');
INSERT INTO `sys_message` VALUES (1391649539160674304, 0, 2, '留言信息10010220011', 'string', 'string', 'string', 'string', b'1', b'1', 0, 'string', '2022-05-21 10:05:32', 'string', '2021-05-10 07:00:51', 'string');
INSERT INTO `sys_message` VALUES (1391649554780262400, 0, 2, '留言信息10010220011', 'string', 'string', 'string', 'string', b'1', b'1', 0, 'string', '2022-03-20 14:28:08', 'string', '2021-05-10 07:00:51', 'string');
INSERT INTO `sys_message` VALUES (1391649555568791552, 0, 2, '留言信息10010220011', 'string', 'string', 'string', 'string', b'1', b'0', 0, 'string', '2022-03-20 14:28:08', 'string', '2021-05-10 07:00:51', 'string');
INSERT INTO `sys_message` VALUES (1391649557682720768, 0, 2, '留言信息10010220011', 'string', 'string', 'string', 'string', b'1', b'0', 0, 'string', '2022-03-20 14:28:11', 'string', '2021-05-10 07:00:51', 'string');
INSERT INTO `sys_message` VALUES (1391649558261534720, 0, 2, '留言信息10010220011', 'string', 'string', 'string', 'string', b'1', b'1', 0, 'string', '2022-03-20 14:28:10', 'string', '2021-05-10 07:00:51', 'string');
INSERT INTO `sys_message` VALUES (1509494310993793025, 0, 1, '问题反馈', 'ddd@qq.com', NULL, NULL, 'sddddddddddd', b'1', b'0', 0, NULL, '2022-05-17 17:10:32', NULL, NULL, NULL);
INSERT INTO `sys_message` VALUES (1509494437967958017, 0, 1, '问题反馈', '2223@qq.com', NULL, NULL, '2222223333333', b'1', b'0', 0, NULL, '2022-05-17 17:10:32', NULL, NULL, NULL);
INSERT INTO `sys_message` VALUES (1511967403649667073, 0, 1, '问题反馈', '121221@qq.com', '', NULL, '12121ssssss', b'1', b'0', 1511955043186774017, 'Jason.付裕', '2022-05-17 17:10:32', NULL, NULL, NULL);

-- ----------------------------
-- Table structure for sys_organize
-- ----------------------------
DROP TABLE IF EXISTS `sys_organize`;
CREATE TABLE `sys_organize`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `ParentId` bigint(20) NOT NULL COMMENT '父节点',
  `Name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '部门名称',
  `Number` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '机构编码',
  `ParentIdList` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '父节点集合',
  `Layer` int(11) NOT NULL DEFAULT 0 COMMENT '部门层级',
  `Sort` int(11) NOT NULL DEFAULT 1 COMMENT '排序',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '状态',
  `IsDel` bit(1) NOT NULL DEFAULT b'0' COMMENT '删除状态',
  `LeaderUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '部门负责人',
  `LeaderMobile` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '联系电话',
  `LeaderEmail` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '联系邮箱',
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `CreateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '组织机构表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_organize
-- ----------------------------
INSERT INTO `sys_organize` VALUES (1247889786656657408, 1247889786656657408, 'Fyt集团', 'aa', '[\"1247889786656657408\",\"1247889786656657408\"]', 1, 1, b'1', b'0', '1', '111123', '1111', '2020-04-08 22:11:24', 'admin', '2022-09-26 00:15:53', 'Admin');
INSERT INTO `sys_organize` VALUES (1248157435479330816, 1247889786656657408, '行政/人事', 'bb', '[\"1247889786656657408\",\"1247889786656657408\",\"1248157435479330816\"]', 2, 2, b'1', b'0', '李四', '12313213', '58555@qq.com', '2020-04-09 15:54:57', 'admin', '2022-09-26 23:45:36', 'Admin');
INSERT INTO `sys_organize` VALUES (1574102857198735360, 1248157435479330816, '撒打算', '123123', '[\"1247889786656657408\",\"1247889786656657408\",\"1248157435479330816\",\"1574102857198735360\"]', 3, 3, b'1', b'0', '123123', '123123', '123123', '2022-09-26 02:25:41', 'Admin', '2022-09-26 02:36:10', 'Admin');

-- ----------------------------
-- Table structure for sys_post
-- ----------------------------
DROP TABLE IF EXISTS `sys_post`;
CREATE TABLE `sys_post`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `Name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '岗位名称',
  `Number` varchar(6) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '岗位编码',
  `Sort` int(11) NOT NULL DEFAULT 1 COMMENT '排序',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '岗位状态',
  `IsDel` bit(1) NOT NULL DEFAULT b'0' COMMENT '删除状态',
  `Summary` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '备注信息',
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `CreateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '岗位表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_post
-- ----------------------------
INSERT INTO `sys_post` VALUES (1251019168074043392, '项目经理', '100001', 1, b'1', b'0', '项目经理', '2020-04-17 13:26:27', 'admin', NULL, NULL);
INSERT INTO `sys_post` VALUES (1251019232876040192, '测试经理', '100002', 2, b'1', b'0', '测试经理', '2020-04-17 13:26:27', 'admin', '0001-01-01 00:00:00', NULL);

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `Name` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '角色名称',
  `ParentId` bigint(20) NULL DEFAULT NULL COMMENT '角色父节点',
  `ParentIdList` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '父节点结合',
  `Layer` int(11) NOT NULL DEFAULT 1 COMMENT '角色层级',
  `Number` varchar(6) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '角色编号',
  `IsSystem` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否超级管理员',
  `Status` bit(1) NOT NULL DEFAULT b'1' COMMENT '状态',
  `Sort` int(11) NOT NULL DEFAULT 1 COMMENT '排序',
  `Summary` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '描述',
  `Console` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '控制台',
  `IsDel` bit(1) NOT NULL DEFAULT b'0' COMMENT '是否删除',
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `CreateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '角色表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES (1339755942329323520, '管理员', 0, '[\"1339755942329323520\",\"1339755942329323520\",\"1339755942329323520\"]', 1, '123', b'0', b'1', 2, '2222', 'work', b'0', '2020-12-18 10:14:42', NULL, '2022-04-25 17:19:49', 'Admin');
INSERT INTO `sys_role` VALUES (1339756014718816256, '系统管理员', 1339755942329323520, '[\"1339755942329323520\",\"1339755942329323520\",\"1339755942329323520\",\"1339756014718816256\"]', 2, NULL, b'1', b'1', 1, '123123123', NULL, b'0', '2020-12-18 10:15:00', NULL, '2022-09-27 00:26:12', 'Admin');
INSERT INTO `sys_role` VALUES (1339770084108931072, '业务管理员', 1339755942329323520, '[\"1339755942329323520\",\"1339770084108931072\"]', 2, '789', b'0', b'1', 3, NULL, 'work', b'0', '2020-12-18 11:10:54', NULL, '0001-01-01 00:00:00', '\0');
INSERT INTO `sys_role` VALUES (1474270544022081536, '操作员', 0, '[1474270544022081536]', 1, '123', b'0', b'1', 4, NULL, 'work', b'0', '2020-12-18 10:14:42', NULL, '0001-01-01 00:00:00', '\0');
INSERT INTO `sys_role` VALUES (1474270613328760833, '审核员', 1474270544022081536, '[\"1474270544022081536\",\"1474270613328760833\"]', 2, '123', b'0', b'1', 5, NULL, 'stats', b'0', '2020-12-18 10:14:42', NULL, '0001-01-01 00:00:00', '');
INSERT INTO `sys_role` VALUES (1474270654994976769, '复审员', 1474270544022081536, '[\"1474270544022081536\",\"1474270654994976769\"]', 2, '123', b'0', b'1', 6, NULL, 'work', b'0', '2020-12-18 10:14:42', NULL, '0001-01-01 00:00:00', '\0');
INSERT INTO `sys_role` VALUES (1474270785488162818, '数据管理员', 1339755942329323520, '[\"1339755942329323520\",\"1474270785488162818\"]', 2, '789', b'0', b'1', 7, NULL, 'work', b'0', '2020-12-18 11:10:54', NULL, '0001-01-01 00:00:00', '');

-- ----------------------------
-- Table structure for sys_scheduler
-- ----------------------------
DROP TABLE IF EXISTS `sys_scheduler`;
CREATE TABLE `sys_scheduler`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `JobName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '任务名称',
  `JobGroup` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '任务组',
  `BeginTime` datetime NOT NULL COMMENT '开始时间',
  `EndTime` datetime NULL DEFAULT NULL COMMENT '结束时间',
  `Cron` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT 'Cron表达式',
  `TriggerType` int(11) NOT NULL DEFAULT 1 COMMENT '触发器类型',
  `RequestUrl` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '请求url',
  `RequestParameters` varchar(900) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '请求参数（Post，Put请求用）',
  `Headers` varchar(900) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT 'Headers',
  `RequestType` int(11) NOT NULL DEFAULT 2 COMMENT '请求类型',
  `Description` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '描述',
  `TriggerState` int(11) NULL DEFAULT 0 COMMENT '任务状态',
  `LastErrMsg` varchar(900) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '上次执行异常信息',
  `PreviousFireTime` datetime NULL DEFAULT NULL COMMENT '上次执行时间',
  `NextFireTime` datetime NULL DEFAULT NULL COMMENT '下次执行时间',
  `CreateTime` datetime NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '任务调度' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_scheduler
-- ----------------------------
INSERT INTO `sys_scheduler` VALUES (1458633937034285057, 'Dd_Task_1', '调度组', '2021-11-11 11:13:20', '2021-11-26 00:00:00', '0 0/10 * * * ? ', 1, 'http://localhost:5000/quartz/test', NULL, NULL, 1, NULL, 0, NULL, NULL, NULL, '2021-11-11 11:13:25');
INSERT INTO `sys_scheduler` VALUES (1460438296701308928, 'Task1', '任务组', '2021-11-10 17:09:35', '2021-11-26 00:00:00', '0 0/10 * * * ? ', 1, 'http://localhost:5000/quartz/test', NULL, NULL, 1, NULL, 0, NULL, NULL, NULL, '2021-11-10 17:10:15');

-- ----------------------------
-- Table structure for sys_vote
-- ----------------------------
DROP TABLE IF EXISTS `sys_vote`;
CREATE TABLE `sys_vote`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `Title` varchar(90) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '0' COMMENT '投票标题',
  `Type` int(11) NOT NULL DEFAULT 1 COMMENT '投票类型（图文、视频、分组）',
  `StartTime` datetime NOT NULL COMMENT '开始时间',
  `EndTime` datetime NOT NULL COMMENT '结束时间',
  `TickRule` int(11) NOT NULL DEFAULT 1 COMMENT '勾选规则（单选、多选）',
  `SwipeRule` bit(1) NOT NULL DEFAULT b'1' COMMENT '防刷规则（IP限制）',
  `FileUrl` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '文件地址',
  `Summary` varchar(900) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '规则',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `CreateUser` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间',
  `UpdateUser` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '投票表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_vote
-- ----------------------------
INSERT INTO `sys_vote` VALUES (1524656155928956928, '疫情的防控措施该如何进行？', 1, '2022-05-04 00:00:00', '2022-05-27 00:00:00', 2, b'1', '', '', '2022-05-12 15:42:09', 'Admin', '2022-05-12 17:25:53', 'Admin');

-- ----------------------------
-- Table structure for sys_vote_item
-- ----------------------------
DROP TABLE IF EXISTS `sys_vote_item`;
CREATE TABLE `sys_vote_item`  (
  `Id` bigint(20) NOT NULL COMMENT '唯一编号',
  `VoteId` bigint(20) NOT NULL DEFAULT 0 COMMENT '投票编号',
  `Title` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '投票项标题',
  `Count` int(11) NOT NULL DEFAULT 0 COMMENT '投票数量',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `CreateUser` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '投票项' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_vote_item
-- ----------------------------
INSERT INTO `sys_vote_item` VALUES (1524656155954122752, 1524656155928956928, '居家办公，不聚集', 15, '2022-05-12 15:42:09', 'Admin');
INSERT INTO `sys_vote_item` VALUES (1524656155954122753, 1524656155928956928, '根据疫情情况，阶段性管控', 30, '2022-05-12 15:42:09', 'Admin');
INSERT INTO `sys_vote_item` VALUES (1524656155954122754, 1524656155928956928, '不用管，该干什么还干什么', 82, '2022-05-12 15:42:09', 'Admin');

-- ----------------------------
-- Table structure for sys_vote_log
-- ----------------------------
DROP TABLE IF EXISTS `sys_vote_log`;
CREATE TABLE `sys_vote_log`  (
  `Id` bigint(20) NOT NULL DEFAULT 0 COMMENT '唯一编号',
  `VoteId` bigint(20) NOT NULL DEFAULT 0 COMMENT '投票编号',
  `VoteItemId` bigint(20) NOT NULL DEFAULT 0 COMMENT '投票项编号',
  `UserId` bigint(20) NOT NULL DEFAULT 0 COMMENT '用户编号',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `CreateUser` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '创建人',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '投票日志' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_vote_log
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;
